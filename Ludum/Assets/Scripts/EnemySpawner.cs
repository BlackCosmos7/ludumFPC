using UnityEngine;
using UnityEngine.SceneManagement; // Не забудьте добавить это
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Массив префабов противников
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
            if (currentEnemyCount < maxEnemies && !GameObject.FindGameObjectWithTag("Enemy"))
            {
                SpawnEnemy();
                currentEnemyCount++;
            }
            yield return new WaitForSeconds(2f); // Ждать 3 секунды
        }

        // После спавна всех врагов ждем 20 секунд и отправляем игрока на следующую сцену
        yield return new WaitForSeconds(10f);
        LoadNextScene();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        // Случайный выбор противника из массива
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    void LoadNextScene()
    {
        // Замените "NextSceneName" на название вашей следующей сцены
        SceneManager.LoadScene("NextSceneName");
    }
}
