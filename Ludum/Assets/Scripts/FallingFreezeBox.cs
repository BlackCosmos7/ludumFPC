using UnityEngine;

public class FallingFreezeBox : MonoBehaviour
{
    public float fallSpeed = 2f; // �������� �������
    public float lifespan = 5f; // ����� ����� �������
    public EnemyFreeze[] enemiesToFreeze; // ������ ������, ������� ����� ����������
    public float freezeDuration = 5f; // ������������ ���������

    private void Start()
    {
        Destroy(gameObject, lifespan); // ���������� ������� ����� �������� �����
    }

    private void Update()
    {
        // ������� ������� ����
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnMouseDown() // ���������� ��� ����� �� �������
    {
        DestroyBox(); // ���������� �������
    }

    private void DestroyBox()
    {
        // ������������ ������
        foreach (var enemy in enemiesToFreeze)
        {
            if (enemy != null)
            {
                enemy.Freeze(freezeDuration); // ������������ �����
            }
        }

        // ����� ����� �������� ������� ����������, ��������, ���� ��� ��������
        Destroy(gameObject); // ���������� �������
    }
}
