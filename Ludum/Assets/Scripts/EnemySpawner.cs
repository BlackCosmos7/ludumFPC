using UnityEngine;
using UnityEngine.SceneManagement; // �� �������� �������� ���
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ������ �������� �����������
    public Transform player;
    public int maxEnemies = 10; // ������������ ���������� ������
    private int currentEnemyCount = 0; // ������� ���������� ������

    public AudioClip spawnSound; // ���� ������
    private AudioSource audioSource; // ��������� AudioSource

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // ��������� AudioSource
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
            if (currentEnemyCount < maxEnemies && !GameObject.FindGameObjectWithTag("Enemy"))
            {
                SpawnEnemy();
                currentEnemyCount++;
            }
            yield return new WaitForSeconds(2f); // ����� 2 �������
        }

        // ����� ������ ���� ������ ���� 20 ������ � ���������� ������ �� ��������� �����
        yield return new WaitForSeconds(10f);
        LoadNextScene();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        // ��������� ����� ���������� �� �������
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        // ����������� ���� ������
        PlaySpawnSound();
    }

    void PlaySpawnSound()
    {
        if (spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

    void LoadNextScene()
    {
        // �������� "NextSceneName" �� �������� ����� ��������� �����
        SceneManager.LoadScene("Level2");
    }
}