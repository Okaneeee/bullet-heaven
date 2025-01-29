using UnityEngine;

public class IDamager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float damage = 50.0f;
    
    [Header("Effects")]
    [SerializeField]
    private AudioClip hitSound;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<EnemyBehavior>();
            enemy.TakeDamage(damage);
            DestroyThyself();
        }
    }

    private void DestroyThyself()
    {
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
        
        Destroy(gameObject);
    }
}
