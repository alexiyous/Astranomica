using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type3_Enemy_Attack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float lastShotTime = 0f;
    public float fireballSpeed = 1.5f;
    public float fireballTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastShotTime >= fireballTime)
        {
            //Reset the last shot time
            lastShotTime = Time.time;
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, -fireballSpeed);

        }
    }
}
