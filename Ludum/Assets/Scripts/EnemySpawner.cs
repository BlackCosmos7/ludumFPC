using UnityEngine;
using UnityEngine.SceneManagement; // Не забудьте добавить это
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public int maxEnemies = 10; // Максимальное количество врагов
    private int currentEnemyCount = 0; // Текущее количество врагов

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
            yield return new WaitForSeconds(3f); // Ждать 10 секунд
        }

        // После спавна всех врагов ждем 20 секунд и отправляем игрока на следующую сцену
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
        // Замените "NextSceneName" на название вашей следующей сцены
        SceneManager.LoadScene("NextSceneName");
    }
}
