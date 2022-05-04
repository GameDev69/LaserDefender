using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    [SerializeField] private int scoreForNextLevel = 2000;

    private void Start()
    {
        // Очки для прохождения на след. уровень = текущ + заданное
        scoreForNextLevel += FindObjectOfType<GameSession>().GetScore();
    }

    public void LoadNextScene(int currentScore)
    {
        if (currentScore >= scoreForNextLevel)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            try
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
