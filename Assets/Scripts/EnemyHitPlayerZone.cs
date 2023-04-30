using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthManager_v1.playerHealth -= 1f;
            Destroy(other.gameObject);
        }
    }
}
