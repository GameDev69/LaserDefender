using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private GameSession _gameSession;
    void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    
    void Update()
    {
        _scoreText.text = _gameSession.GetScore().ToString();
    }
}
