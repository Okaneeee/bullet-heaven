using UnityEngine;

public class IDamager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float damage = 50.0f;
    [SerializeField]
    private bool shouldDestroyOnHit = true;
    
    [Header("Effects")]
    [SerializeField]
    private AudioClip hitSound;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<EnemyBehavior>();
            enemy.TakeDamage(damage);
            if(shouldDestroyOnHit)
            {
                DestroyThyself();
            }
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
