using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField]
    private string gameScene;
    [SerializeField]
    private string mainMenuScene;
    
    public void Replay()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
