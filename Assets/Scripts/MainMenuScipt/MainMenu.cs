using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void goToCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void goToTutorial()
    {
        SceneManager.LoadScene("Tutor1");
    }
}
