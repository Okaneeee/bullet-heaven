using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior Instance { get; private set; }
    
    [Header("Stats")]
    [SerializeField]
    private float health = 100.0f;
    [SerializeField]
    private float damage = 34.0f;
    
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
    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        
        if (health <= 0)
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
