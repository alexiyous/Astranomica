using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;

    public Vector2 moveDIR;

    public Animator anim;
    public int damageAmount = 1;
    // Update is called once per frame
    void Update()
    {
        theRB.velocity = bulletSpeed * moveDIR;
    }

    // a function so that the bullet will gone everytime it collides with a collision (ex:wall,gorund,etc)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")//everytime the bullet hits the enemy, it calls the damaging function so it deplete the health
        {
            other.GetComponent<Type1_EnemyHealt>().TakeDamage(3);
            StartCoroutine(ShowImpact());
        }
    }

    // a function so that the bullet will gone when it's off screen or off the camera range of view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator ShowImpact()
    {
        anim.SetTrigger("impact");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
