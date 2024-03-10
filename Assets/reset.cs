using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody carRigidbody;
    private List<Vector3> positionsHistory = new List<Vector3>(); // Store positions history

    void Start()
    {
        // Store the initial position and rotation of the car
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Get the car's rigidbody component
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if you want to reset the car (for example, if a certain key is pressed)
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ResetCar());
        }

        // Store the car's position at regular intervals
        if (Time.frameCount % 60 == 0) // Store position every 60 frames (1 second at 60fps)
        {
            StorePosition();
        }
    }

    void StorePosition()
    {
        positionsHistory.Add(transform.position);
    }

    IEnumerator ResetCar()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        // Stop the car's movement
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;

        // Retrieve the position from 5 seconds ago
        if (positionsHistory.Count >= 5)
        {
            Vector3 previousPosition = positionsHistory[positionsHistory.Count - 5];
            transform.position = previousPosition;
        }
        else
        {
            // If there's not enough history, reset to initial position
            transform.position = initialPosition;
        }
    }
}


}
