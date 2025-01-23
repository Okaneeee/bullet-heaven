using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
