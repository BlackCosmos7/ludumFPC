using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 3.0f;
    public float damage = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogWarning("Player not found! Make sure the Player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage); // Передаем урон в метод
            }
            Destroy(gameObject);
        }
    }
}

