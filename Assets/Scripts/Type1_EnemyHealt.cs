using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1_EnemyHealt : MonoBehaviour
{
    [SerializeField] private float health = 2f;
    private Rigidbody2D rb;
    public int pointValue = 100;
    public Animator anim;
    public Color colorChange = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    public Color defaultColor;
    public SpriteRenderer spriteRenderer;
    public float hitduration = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(changeColorWhenHit(hitduration));
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

    private IEnumerator changeColorWhenHit(float duration)
    {
        spriteRenderer.color = colorChange;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = defaultColor;
    }

 }
