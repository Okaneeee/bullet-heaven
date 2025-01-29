using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float health = 100.0f;
    [SerializeField]
    private float damage = 15f;
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int xpValue = 15;
    
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Move towards the player
        if (_player != null)
        {
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
            PlayerBehavior.Instance.TakeDamage(damage);
        }
    }

    private void Die()
    {
        TimeAndScore.Instance.AddScore(10);
        XPManager.Instance.AddXP(xpValue);
        Destroy(gameObject);
    }
    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        
        if (health <= 0)
        {
            Die();
        }
    }
}
