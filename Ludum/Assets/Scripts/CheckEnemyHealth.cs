using UnityEngine;

public class CheckEnemyHealth : MonoBehaviour
{
    void Update()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();

        if (enemyStats.health <= 0) 
        {
            Destroy(gameObject); 
        }
    }
}