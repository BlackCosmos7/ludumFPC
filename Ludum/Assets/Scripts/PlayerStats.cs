using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public float hp = 3;
    public TextMeshProUGUI hpText;
    public float jumpForce = 7f;

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

    void Die()
    {
        SceneManager.LoadScene("DeadScreen");
    }
    

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            //if (DeadScreen.activeSelf)
            //{
            //    DeadScreen.SetActive(true);
            //}
            hp = 0;
            {
                Die();
            }
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

    //void Update()
    //{
     //   Jump();
    //}

    //void Jump()
    //{
     //   if(Input.GetKeyDown(KeyCode.Space))
      //  {
      //      Rigidbody.velocity = new Vector(Rigidbody.velocity.x, jumpForce);
      //  }
   // }
}
