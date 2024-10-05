using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public GameObject enemy; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
            enemyStats.health -= 1; 
            Debug.Log("Enemy Health: " + enemyStats.health);
        }
    }
}