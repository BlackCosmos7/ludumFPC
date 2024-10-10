using UnityEngine;
using System.Collections;

public class EnemyFreeze : MonoBehaviour
{
    private bool isFrozen = false;

    // ����� ��� ��������� �����
    public void Freeze(float freezeDuration)
    {
        if (!isFrozen)
        {
            StartCoroutine(FreezeCoroutine(freezeDuration));
        }
    }

    private IEnumerator FreezeCoroutine(float freezeDuration)
    {
        isFrozen = true;

        // ��������� �������� �����
        var enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false; // ��������� ��������
        }

        yield return new WaitForSeconds(freezeDuration);

        // ��������������� ��������
        if (enemyMovement != null)
        {
            enemyMovement.enabled = true; // �������� ��������
        }

        isFrozen = false;
    }
}