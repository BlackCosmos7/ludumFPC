using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] boxPrefabs; // ������ �������� �������
    public float spawnInterval = 20f; // �������� ����� ���������� �������

    private void Start()
    {
        InvokeRepeating("SpawnBox", 0f, spawnInterval); // �������� ����� �������
    }

    private void SpawnBox()
    {
        // ���������, ���� �� ������� � �������
        if (boxPrefabs.Length > 0)
        {
            // �������� ��������� ������ �� �������
            GameObject boxPrefab = boxPrefabs[Random.Range(0, boxPrefabs.Length)];

            // ������� ��� ������ (�� ������ ������ �� ����������� � ��� ������� �� ���������)
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f); // �������� ���������� � ����������� �� ����� �����
            Instantiate(boxPrefab, spawnPosition, Quaternion.identity); // ������ �������
        }
    }
}