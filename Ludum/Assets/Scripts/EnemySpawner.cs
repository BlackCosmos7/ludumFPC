using UnityEngine;
using UnityEngine.SceneManagement; // �� �������� �������� ���
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
            if (!GameObject.FindGameObjectWithTag("Enemy"))
            {
                SpawnEnemy();
                currentEnemyCount++;
            }
            yield return new WaitForSeconds(3f); // ����� 10 ������
        }

        // ����� ������ ���� ������ ���� 20 ������ � ���������� ������ �� ��������� �����
        yield return new WaitForSeconds(10f);
        LoadNextScene();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void LoadNextScene()
    {
        // �������� "NextSceneName" �� �������� ����� ��������� �����
        SceneManager.LoadScene("NextSceneName");
    }
}
