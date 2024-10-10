using UnityEngine;
using System.Collections;

public class PlayerInvincibility : MonoBehaviour
{
    private bool isInvincible = false;

    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible) // ���������, �� ������� �� ��� ������
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        Debug.Log("Player is now invincible!");

        yield return new WaitForSeconds(duration);

        isInvincible = false;
        Debug.Log("Player is no longer invincible.");
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
