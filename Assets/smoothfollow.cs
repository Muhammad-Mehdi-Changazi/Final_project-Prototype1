using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;         // The player transform to follow
    [SerializeField] private float smoothSpeed = 0.125f; // Smoothing for position
    [SerializeField] private float rotationSmoothSpeed = 0.1f; // Smoothing for rotation
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); // Position offset (height and distance)
    [SerializeField] private Vector3 angleOffset = new Vector3(30, 0, 0); // Angle offset for camera tilt

    private void LateUpdate()
    {
        // Position: Smoothly move the camera to follow the player
        Vector3 desiredPosition = target.position + target.rotation * offset; // Rotate offset with player's rotation
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rotation: Smoothly rotate the camera to match the player's rotation with angle adjustment
        Quaternion targetRotation = Quaternion.Euler(angleOffset) * target.rotation; // Combine angleOffset with player rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed);
    }
}
