using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float health = 100.0f;
    [SerializeField]
    private float speed = 5.0f;
    
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
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
            PlayerBehavior.Instance.TakeDamage(35.0f);
        }
    }

    private void Die()
    {
        TimeAndScore.Instance.AddScore(10);
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
