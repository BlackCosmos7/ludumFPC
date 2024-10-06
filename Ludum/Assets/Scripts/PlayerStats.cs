using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float hp = 3;
    public Text hpText;
    private bool trig;

    void Start()
    {
        hpText.text = ((int)hp).ToString();
    }

    void FixedUpdate()
    {
        if (trig)
        {
            TakeDamage();
            UpdateHpText();
        }
    }

    private void AddHp()
    {
        if (hp < 3)
        {
            hp += 1;
        }

        if (hp > 3)
        {
            hp = 3;
        }
    }

    private void TakeDamage()
    {
        hp -= 1 * Time.deltaTime;

        if (hp < 0)
        {
            hp = 0;
        }
    }

    private void UpdateHpText()
    {
        hpText.text = ((int)hp).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Medicine")
        {
            AddHp();
            UpdateHpText();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            trig = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            trig = false;
        }
    }
}
