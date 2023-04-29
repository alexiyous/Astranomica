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
        foreach(Image img in hearts)
        {
            img.sprite = EmptyHearts;

        }

        for( int i = 0; i < playerHealth; i++)
        {
            hearts[i].sprite = fullHearts;
        }
    }

    
}
