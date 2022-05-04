using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private int _score = 0;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        
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
        _sceneLoader = FindObjectOfType<SceneLoader>();
        _sceneLoader.LoadNextScene(_score);
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
