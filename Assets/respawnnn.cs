using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Rigidbody carRigidbody;
    private GameObject checkpoint; // Changed from Transform to GameObject

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the reset key is pressed (for example, the 'R' key)
        if (Input.GetKeyDown(KeyCode.R))
        {
            PerformReset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Checkpoint = other.gameObject; // Changed from Transform to GameObject
        }
    }

    public void PerformReset()
    {
        if (Checkpoint != null)
        {
            // Reset the car's position and velocity to the checkpoint position
            carRigidbody.velocity = Vector3.zero;
            carRigidbody.angularVelocity = Vector3.zero;
            transform.position = checkpoint.transform.position; // Using the position of the checkpoint GameObject

            Debug.Log("Car reset to checkpoint!");
        }
        else
        {
            Debug.LogWarning("No checkpoint set for reset!");
        }
    }
}

