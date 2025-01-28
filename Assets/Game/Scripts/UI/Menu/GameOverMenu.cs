using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField]
    private string gameScene;
    [SerializeField]
    private string mainMenuScene;
    
    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    
    public void Replay()
    {
        SceneManager.LoadScene(gameScene);
        GameManager.Instance.DestroyThyself();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    
    void Start()
    {
        scoreText.text = $"Score: {GameManager.Instance.GetScore():00000}";
        timeText.text = $"Time alive:<br>{GameManager.Instance.GetTime() / 60:00}:{GameManager.Instance.GetTime() % 60:00}";
    }
}
