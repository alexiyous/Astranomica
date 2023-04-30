using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    public HealthManager_v1 health;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Type1_EnemyHealt enemyHealth = other.GetComponent<Type1_EnemyHealt>();
        Boss_Health_System bossHealt = other.GetComponent<Boss_Health_System>();
        if (other.CompareTag("Enemy"))
        {
            health.playerHealth -= 1f;
            if (enemyHealth != null)
            {
                enemyHealth.Die();
            }
            else if (bossHealt != null)
            { 
                bossHealt.Die();
            }
            if (health.playerHealth <= 0)
            {
                health.GameOver();
            }
        }
    }
}
