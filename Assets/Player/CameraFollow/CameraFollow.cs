using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;             // The target to follow.
    public float smoothSpeed = 5f;       // Smoothness of camera movement.
    public float moveSpeed = 1f;         // Speed of camera movement.
    public float amplitude = 1f;         // Amplitude of camera movement.
    public Vector3 direction = Vector3.right; // Direction of camera movement.

    private Transform cameraTransform;
    private Vector3 initialOffset;

    private void Awake()
    {
        cameraTransform = transform;
        initialOffset = cameraTransform.localPosition;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not set!");
            return;
        }

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + initialOffset + direction * Mathf.Sin(Time.time * moveSpeed) * amplitude;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        cameraTransform.position = smoothedPosition;

        // Make the camera look at the target without rotating with it
        cameraTransform.LookAt(target);

        // Apply anti-roll feature to keep the camera level
        Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}

