using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float hp = 3;
    public TextMeshProUGUI hpText;

    void Start()
    {
        UpdateHpText();
    }

    public void AddHp()
    {
        if (hp < 3)
        {
            hp += 1;
        }

        if (hp > 3)
        {
            hp = 3;
        }
        UpdateHpText();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            hp = 0;
            // Логика смерти
        }

        UpdateHpText();
    }

    public void UpdateHpText()
    {
        hpText.text = ((int)hp).ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Medicine"))
        {
            AddHp();
        }
    }
}
