using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager_v1 : MonoBehaviour
{
    public float playerHealth = 3;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite EmptyHearts;
    public GameObject gameOver;

    private void Start()
    {
        playerHealth = 3;
        gameOver.SetActive(false);
    }

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

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }


}
