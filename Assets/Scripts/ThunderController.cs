using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public float delay;

    public void Start()
    {
        StartCoroutine(StruckAnimation());
    }

    IEnumerator StruckAnimation()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
