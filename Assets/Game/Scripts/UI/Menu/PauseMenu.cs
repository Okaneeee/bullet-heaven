using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }
    
    [SerializeField]
    private GameObject pauseMenu;
    
    private bool _isPaused;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PauseGame()
    {
        _isPaused = !_isPaused;
        pauseMenu.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0 : 1;
    }
    
    public bool GetPauseState()
    {
        return _isPaused;
    }
    
    public void ResumeGame()
    {
        PauseGame();
    }
    
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
