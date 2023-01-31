using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
