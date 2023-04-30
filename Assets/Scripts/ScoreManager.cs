using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString() + " POINTS";
    }
    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString() + " POINTS";
    }
}
