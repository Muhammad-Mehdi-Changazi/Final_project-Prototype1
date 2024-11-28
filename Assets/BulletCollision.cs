using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Bullet collided with: {collision.gameObject.name}");

        // Destroy only this bullet (the GameObject this script is attached to)
        Destroy(gameObject);
    }
}
