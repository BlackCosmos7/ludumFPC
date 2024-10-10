using UnityEngine;
using System.Collections;

public class PlayerClick : MonoBehaviour
{
    public float damageMultiplier = 1; // ��������� �����

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = hit.collider.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    int damage = Mathf.RoundToInt(1 * damageMultiplier); // ��������� ���������
                    enemyStats.TakeDamage(damage); // ����������� ����� TakeDamage
                    Debug.Log("Enemy Health: " + enemyStats.health);
                }
            }
        }
    }

    public void ActivateDamageBoost(float duration)
    {
        StartCoroutine(DamageBoostCoroutine(duration));
    }

    private IEnumerator DamageBoostCoroutine(float duration)
    {
        damageMultiplier = 3; // ����������� ���� � 3 ����
        yield return new WaitForSeconds(duration); // ���� ��������� �����
        damageMultiplier = 1; // ��������������� ������� ����
    }
}
