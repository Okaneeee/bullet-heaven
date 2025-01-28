using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Scenes")]
    [SerializeField]
    private string gameOverScene;
    
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
        SceneManager.LoadScene(gameOverScene);
    }
    
    public void DestroyThyself()
    {
        Destroy(gameObject);
    }
}
