using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver = false;
    public bool IsGameOVer
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
        }
    }

    [SerializeField]
    private int m_Score;
    public int Score
    {
        get { return m_Score; }
        set
        {
            if (value > 0) m_Score = value;
            else m_Score = 0;
            scoreText.text = "score: " + m_Score;
        }
    }

    [SerializeField] TextMeshProUGUI scoreText;
}
