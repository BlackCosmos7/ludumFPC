using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float hp = 3;
    public TextMeshProUGUI hpText;
    private bool trig;

    void Start()
    {
        UpdateHpText();
    }

    void FixedUpdate()
    {
        if (trig)
        {
            TakeDamage();
            UpdateHpText();
        }
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
    }

    public void TakeDamage()
    {
        hp -= 1 * Time.deltaTime;

        if (hp < 0)
        {
           // if (deadScreen.activeSelf)
           // {
           //     deadScreen.SetActive(true);
            //}
            hp = 0;
        }
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
            UpdateHpText();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            trig = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            trig = false;
        }
    }
}