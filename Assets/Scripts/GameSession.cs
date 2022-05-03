using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int _score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
    }

    public int GetScore()
    {
        return _score;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
