using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScore;

    public Scoremanager scoreManager;

    private void Update()
    {
        // Обновление текстовых полей
        if (ScoreText != null)
        {
            int Score = PlayerPrefs.GetInt("Score");
            ScoreText.text = "" + Score;
        }
        if (BestScore != null)
        {
            BestScore.text = "Best Score: " + scoreManager.bestScore; 
        }
    }
}
