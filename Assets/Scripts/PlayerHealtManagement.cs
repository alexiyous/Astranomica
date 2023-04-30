using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtManagement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Type1_EnemyHealt enemyHealth = other.GetComponent<Type1_EnemyHealt>();
        if (other.CompareTag("Enemy"))
        {
            HealthManager_v1.playerHealth -= 1f;
            //enemyHealth.TakeDamage(1f);
            if (HealthManager_v1.playerHealth <= 0)
            {
                //Player is dead, game over
                Debug.Log("game over");
            }
        }
        if (other.CompareTag("Bullet"))
        {
            HealthManager_v1.playerHealth -= 1f;
            Destroy(other.gameObject);
        }
    }
}
