using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1_EnemyHealt : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    public int pointValue = 100;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        /*ScoreManager.instance.AddScore(pointValue);*/
        Destroy(gameObject);
    }
}
