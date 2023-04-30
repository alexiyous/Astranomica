using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;
    public Vector2 moveDIR;

    public Animator anim;
    public int damageAmount = 2;
    // Update is called once per frame
    void Update()
    {
        theRB.velocity = bulletSpeed * moveDIR;
    }

    // a function so that the bullet will gone everytime it collides with a collision (ex:wall,gorund,etc)
    private void OnTriggerEnter2D(Collider2D other)
    {
        Type1_EnemyHealt enemy = other.GetComponent<Type1_EnemyHealt>();
        Boss_Health_System bos = other.GetComponent<Boss_Health_System>();

        if (other.tag == "Enemy")//everytime the bullet hits the enemy, it calls the damaging function so it deplete the health
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
                moveDIR = Vector2.zero;
                StartCoroutine(ShowImpact());
                
            }

            if (bos != null)
            {
                bos.TakeDamage(damageAmount);
                moveDIR =  Vector2.zero;
                StartCoroutine(ShowImpact());
            }
        }
    }

    // a function so that the bullet will gone when it's off screen or off the camera range of view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator ShowImpact()
    {
        anim.SetTrigger("splash");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
