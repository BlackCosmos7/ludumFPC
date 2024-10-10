using UnityEngine;
using System.Collections;

public class EnemyFreeze : MonoBehaviour
{
    private bool isFrozen = false;

    // Метод для заморозки врага
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

        // Отключаем движение врага
        var enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false; // Отключаем движение
        }

        yield return new WaitForSeconds(freezeDuration);

        // Восстанавливаем движение
        if (enemyMovement != null)
        {
            enemyMovement.enabled = true; // Включаем движение
        }

        isFrozen = false;
    }
}