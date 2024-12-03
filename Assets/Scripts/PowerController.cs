using UnityEngine;

public class PowerController : MonoBehaviour
{
    public GameObject fireBulletPrefab;   // Prefab for Fire Power
    public GameObject waterBulletPrefab; // Prefab for Water Power
    public GameObject earthBulletPrefab; // Prefab for Earth Power
    public Transform firePoint;          // Point where bullets spawn
    public float bulletSpeed = 10f;      // Speed of the bullets

    void Update()
    {
        // Check for key presses and shoot respective bullets
        if (Input.GetKeyDown(KeyCode.F)) // Fire bullet
        {
            Shoot(fireBulletPrefab);
        }
        if (Input.GetKeyDown(KeyCode.G)) // Earth bullet
        {
            Shoot(earthBulletPrefab);
        }
        if (Input.GetKeyDown(KeyCode.H)) // Water bullet
        {
            Shoot(waterBulletPrefab);
        }
    }

    void Shoot(GameObject bulletPrefab)
    {
        // Instantiate the bullet at the fire point with the same rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Ensure the bullet moves in the fire point's forward direction
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Vector3 bulletDirection = firePoint.forward.normalized; // Get the firePoint's forward direction
        rb.linearVelocity = bulletDirection * bulletSpeed;            // Apply velocity to the bullet

        // Destroy the bullet after 5 seconds to prevent clutter
        Destroy(bullet, 5f);
    }
}
