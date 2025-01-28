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
    [SerializeField]
    private float damage = 34.0f;
    
    [SerializeField]
    private Slider healthBar;
    
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
    }
    
    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        healthBar.value = _currentHealth;
        
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
}
