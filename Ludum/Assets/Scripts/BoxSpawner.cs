using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] boxPrefabs; // Массив префабов коробок
    public float spawnInterval = 20f; // Интервал между появлением коробок

    private void Start()
    {
        InvokeRepeating("SpawnBox", 0f, spawnInterval); // Начинаем спавн коробок
    }

    private void SpawnBox()
    {
        // Проверяем, есть ли префабы в массиве
        if (boxPrefabs.Length > 0)
        {
            // Выбираем случайный префаб из массива
            GameObject boxPrefab = boxPrefabs[Random.Range(0, boxPrefabs.Length)];

            // Позиция для спавна (по центру экрана по горизонтали и над экраном по вертикали)
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f); // Измените координаты в зависимости от вашей сцены
            Instantiate(boxPrefab, spawnPosition, Quaternion.identity); // Создаём коробку
        }
    }
}