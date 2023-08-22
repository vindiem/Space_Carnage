using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    //public static ScoreManager instance;

    public int bestScore = 0; // Лучший результат
    public int Score = 0; // Счетчик убитых врагов

    private void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

        // Загрузка лучшего результата из PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    public void EnemyKilled()
    {
        Score++;
        PlayerPrefs.SetInt("Score", Score);

        // Обновление лучшего результата, если необходимо
        if (Score > bestScore)
        {
            bestScore = Score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
