using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1_EnemyHealt : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    private Rigidbody2D rb;
    public int pointValue = 100;
    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
            AddScore();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        GetComponent<EnemyMoveBottom>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,1f);
    }

    public void AddScore()
    {
        ScoreManager.instance.AddScore(pointValue);
    }
}
