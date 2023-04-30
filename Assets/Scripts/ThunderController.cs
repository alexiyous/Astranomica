using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public float delay;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Type1_EnemyHealt enemy = other.GetComponent<Type1_EnemyHealt>();
        Boss_Health_System bos = other.GetComponent<Boss_Health_System>();
        if (other.tag == "Enemy")
        {
            if (enemy != null)
            {
                StartCoroutine(StruckAnimation());
            }
            if (bos != null)
            {
                StartCoroutine(StruckAnimation());
            }
        }
    }

    IEnumerator StruckAnimation()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
