using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody carRigidbody;

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
        // Check if you want to restart the car (for example, if a certain key is pressed)
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(RestartCar());
        }
    }

    IEnumerator RestartCar()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Stop the car's movement
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;

        // Move the car back to its initial position and rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}