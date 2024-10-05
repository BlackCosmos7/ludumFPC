using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 10f;
    public float moveSpeed = 5f;

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distanceToPlayer = direction.magnitude;

        if (distanceToPlayer <= attackRange)
        {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
    }
}