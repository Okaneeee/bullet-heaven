using TMPro;
using UnityEngine;

public class DisplayGameVersio : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI versionText;
    
    void Start()
    {
        versionText.text = $"v{Application.version}";
    }
}
