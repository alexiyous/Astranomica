using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }
    private void Update()
    {
        
    }
}
