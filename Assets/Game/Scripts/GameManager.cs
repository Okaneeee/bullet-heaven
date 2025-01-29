using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Scenes")]
    [SerializeField]
    private string gameOverScene;

    private int _gameScore;
    private float _gameTime;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void GameOver()
    {
        _gameScore = TimeAndScore.Instance.GetScore();
        _gameTime = TimeAndScore.Instance.GetTimeElapsed();
        SceneManager.LoadScene(gameOverScene);
    }
    
    public void DestroyThyself()
    {
        Destroy(gameObject);
    }
    
    public int GetScore()
    {
        return _gameScore;
    }
    
    public float GetTime()
    {
        return _gameTime;
    }
}
