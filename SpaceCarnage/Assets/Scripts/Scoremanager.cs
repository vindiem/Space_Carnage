using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    //public static ScoreManager instance;

    public int bestScore = 0; // ������ ���������
    public int Score = 0; // ������� ������ ������

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

        // �������� ������� ���������� �� PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    public void EnemyKilled()
    {
        Score++;
        PlayerPrefs.SetInt("Score", Score);

        // ���������� ������� ����������, ���� ����������
        if (Score > bestScore)
        {
            bestScore = Score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
