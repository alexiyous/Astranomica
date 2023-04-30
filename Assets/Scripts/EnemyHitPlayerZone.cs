using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Type1_EnemyHealt enemyHealth = other.GetComponent<Type1_EnemyHealt>();
        Boss_Health_System bossHealt = other.GetComponent<Boss_Health_System>();
        if (other.CompareTag("Enemy"))
        {
            HealthManager_v1.playerHealth -= 1f;
            if (enemyHealth != null)
            {
                enemyHealth.Die();
            }
            else if(bossHealt != null)
            {
                bossHealt.Die();
            }
            if (HealthManager_v1.playerHealth <= 0)
            {
                // Player is dead, game over
            }
        }
    }
}
