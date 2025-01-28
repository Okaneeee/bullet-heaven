using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField]
    private string sceneName;
    
    [Header("Panels")]
    [SerializeField]
    private GameObject[] panels;
    
    [SerializeField]
    private GameObject settingsPanel;
    
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        foreach(var panel in panels)
        {
            panel.SetActive(false);
        }

        settingsPanel.SetActive(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
