using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death_anim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
