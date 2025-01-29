using UnityEngine;

public class ShootAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float attackFrequency = 1.5f;
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float lifeTime = 3.0f;
    
    [Header("Effects")]
    [SerializeField]
    private AudioClip shootSound;

    [Header("Editor")]
    [SerializeField]
    private GameObject parent;
    
    private float _timeSinceLastAttack = 0.0f;
    

    // Update is called once per frame
    void Update()
    {
        Shoot();
        _timeSinceLastAttack += Time.deltaTime;
    }

    private void Shoot()
    {
        if (_timeSinceLastAttack >= attackFrequency)
        {
            Transform bodyTransform = transform.GetChild(0).transform;
            
            // Instantiate the projectile
            GameObject newProjectile = Instantiate(projectile, bodyTransform.position + bodyTransform.forward, bodyTransform.rotation, parent.transform);
        
            // Set the projectile's velocity
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            rb.linearVelocity = bodyTransform.forward * (speed + speed);

            // Play the shoot sound
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }

            // Destroy the projectile after its lifetime
            Destroy(newProjectile, lifeTime);

            // Reset the attack timer
            _timeSinceLastAttack = 0.0f;
        }
    }
}
