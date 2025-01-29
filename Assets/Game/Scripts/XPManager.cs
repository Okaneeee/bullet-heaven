using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    public static XPManager Instance { get; private set; }
    
    [Header("XP")]
    [SerializeField]
    private int XP = 0;
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private int xpToNextLevel = 100;
    [SerializeField] [Min(1)]
    [Tooltip("Increase the amount of XP needed to level up by this amount")]
    private float xpMultIncrement = 1.5f;
    
    [Header("UI Elements")]
    [SerializeField]
    private Slider XPBar;
    [SerializeField]
    private TextMeshProUGUI lvlText;
    
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
    
    void Start()
    {
        XPBar.maxValue = xpToNextLevel;
        XPBar.value = XP;
        
        lvlText.text = $"Level {level}";
    }
    
    public void AddXP(int xp)
    {
        XP += xp;
        XPBar.value = XP;
        
        if (XP >= xpToNextLevel)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        level++;
        lvlText.text = $"Level {level}";
        
        XP -= xpToNextLevel;
        XPBar.value = XP;
        
        xpToNextLevel = (int)(xpToNextLevel * xpMultIncrement);
        
        XPBar.maxValue = xpToNextLevel;
        
        LevelReached();
    }

    private void LevelReached()
    {
        SpinningOrbAttack.Instance.IncreaseOrbs(); 
    }
}
