using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager_v1 : MonoBehaviour
{
    public static float playerHealth = 3;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite EmptyHearts;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].sprite = fullHearts;
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].sprite = null;
                hearts[i].color = Color.clear;
            }
        }
    }


}
