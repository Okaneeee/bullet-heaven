using System;
using UnityEngine;

public class IDamager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float damage = 50.0f;
    
    [Header("Effects")]
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private AudioClip hitSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
        // Instantiate the hit effect
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
        
        Destroy(gameObject);
    }
}
