using UnityEngine;

public class FallingDamageBox : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float lifespan = 5f; // ����� ����� �������
    public float damageBoostDuration = 5f; // ������������ ���������� �����

    private void Start()
    {
        Destroy(gameObject, lifespan); // ���������� ������� ����� �������� �����
    }

    private void OnMouseDown() // ���������� ��� ����� �� �������
    {
        DestroyBox(); // ���������� �������
    }

    private void DestroyBox()
    {
        PlayerClick playerClick = FindObjectOfType<PlayerClick>();
        if (playerClick != null)
        {
            playerClick.ActivateDamageBoost(damageBoostDuration); // ���������� ���������� �����
        }

        // ����� ����� �������� ������� ����������, ��������, ���� ��� ��������
        Destroy(gameObject); // ���������� �������
    }
}