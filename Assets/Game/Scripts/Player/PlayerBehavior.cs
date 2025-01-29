using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior Instance { get; private set; }
    
    [FormerlySerializedAs("health")]
    [Header("Stats")]
    [SerializeField]
    private float maxHealth = 100.0f;
    private float _currentHealth;
    
    [Header("UI Elements")]
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TextMeshProUGUI healthText;
    
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
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        
        _currentHealth = maxHealth;
        UpdateHealthText();
    }
    
    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        healthBar.value = _currentHealth;
        UpdateHealthText();
        
        if (_currentHealth <= 0)
        {
            Die();
        }
        
    }
    
    private void Die()
    {   
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
    
    private void UpdateHealthText()
    {
        healthText.text = $"{_currentHealth:00}%";
    }
}
