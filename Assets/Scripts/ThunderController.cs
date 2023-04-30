using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public float delay;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(StruckAnimation());
        }
    }

    IEnumerator StruckAnimation()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
