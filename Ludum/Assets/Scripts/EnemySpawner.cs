using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = player.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
