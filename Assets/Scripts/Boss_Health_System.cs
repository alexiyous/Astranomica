using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health_System : MonoBehaviour
{
    [SerializeField] private float health = 2f;
    private Rigidbody2D rb;
    public int pointValue = 50;
    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            AddScore();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        GetComponent<Boss>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }

    public void AddScore()
    {
        ScoreManager.instance.AddScore(pointValue);
    }
}
