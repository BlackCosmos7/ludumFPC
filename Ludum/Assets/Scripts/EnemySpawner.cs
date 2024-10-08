using UnityEngine;
using UnityEngine.SceneManagement; // �� �������� �������� ���
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ������ �������� �����������
    public Transform player;
    public int maxEnemies = 10; // ������������ ���������� ������
    private int currentEnemyCount = 0; // ������� ���������� ������

    void Start()
    {
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
            yield return new WaitForSeconds(2f); // ����� 3 �������
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
    }

    void LoadNextScene()
    {
        // �������� "NextSceneName" �� �������� ����� ��������� �����
        SceneManager.LoadScene("NextSceneName");
    }
}
