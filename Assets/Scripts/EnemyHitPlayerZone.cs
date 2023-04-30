using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Type1_EnemyHealt enemyHealth = other.GetComponent<Type1_EnemyHealt>();
        if (other.CompareTag("Enemy"))
        {
            HealthManager_v1.playerHealth -= 1f;
            //Destroy(other.gameObject);
            enemyHealth.TakeDamage(10f);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
