using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Assign your particle prefab in the Inspector
    public AudioClip collisionSound;       // Assign your sound effect in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Ensure there is an AudioSource component on the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Prevents the sound from playing when the game starts
    }

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate the particle effect at the collision point
        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }

        // Play the collision sound
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
