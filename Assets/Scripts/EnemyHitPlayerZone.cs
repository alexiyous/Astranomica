using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            HealthManager_v1.playerHealth -= 0.5f;
            Destroy(other.gameObject);            
            if (HealthManager_v1.playerHealth <= 0)
            {
                // Player is dead, game over
            }
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
