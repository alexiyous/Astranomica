using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);            
        }
    }
}
