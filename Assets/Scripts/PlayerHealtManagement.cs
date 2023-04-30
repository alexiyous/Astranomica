using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtManagement : MonoBehaviour
{
    public HealthManager_v1 health;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Type1_EnemyHealt enemyHealth = other.GetComponent<Type1_EnemyHealt>();
        if (other.CompareTag("Enemy"))
        {
            health.playerHealth -= 1f;
            //enemyHealth.TakeDamage(1f);
            if (health.playerHealth <= 0)
            {
                //Player is dead, game over
                Debug.Log("game over");
            }
        }
        if (other.CompareTag("Bullet"))
        {
            health.playerHealth -= 1f;
            Destroy(other.gameObject);
        }
    }
}
