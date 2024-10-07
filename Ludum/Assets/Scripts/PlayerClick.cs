using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = hit.collider.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.health -= 1;
                    Debug.Log("Enemy Health: " + enemyStats.health);

                    
                    if (enemyStats.health <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}