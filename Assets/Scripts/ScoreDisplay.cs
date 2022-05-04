using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private GameSession _gameSession;
    private int _currentScore;
    void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        _gameSession = FindObjectOfType<GameSession>();
    }
    
    void Update()
    {
        _currentScore = _gameSession.GetScore();
        if (_currentScore <= 0)
        {
            _currentScore = 0;
        }
        _scoreText.text = _gameSession.GetScore().ToString();
    }
}
