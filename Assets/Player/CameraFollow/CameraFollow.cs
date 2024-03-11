using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // The target to follow.
    public Vector3 offset = new Vector3(0f, 3f, -5f);  // Offset from the target.
    public float smoothSpeed = 5f;  // Smoothness of camera movement.

    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = transform;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not set!");
            return;
        }

        // Calculate the desired position for the camera.
        Vector3 desiredPosition = target.position + offset;

        // Update the camera position without smoothing.
        cameraTransform.position = desiredPosition;

        // Make the camera look at the target.
        cameraTransform.LookAt(target);
    }
}

