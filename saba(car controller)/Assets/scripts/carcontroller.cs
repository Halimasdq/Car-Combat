using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider RRCollider;
    public WheelCollider RLCollider;
    public WheelCollider FRCollider;
    public WheelCollider FLCollider;

    public float maxTorque = 100f;
    public float maxBrakeTorque = 3000f; // Adjust this as needed for your car
    public float maxSteerAngle = 30f;    // Adjust this as needed for your car

    private float carAccel;
    private float carSteer;

    void Update()
    {
        carAccel = Input.GetAxis("Vertical");
        carSteer = Input.GetAxis("Horizontal");
        
        // Check if the spacebar (or any key you prefer) is pressed to apply brakes.
        if (Input.GetKey(KeyCode.Space))
        {
            // Apply braking torque to all wheels (adjust maxBrakeTorque as needed).
            RLCollider.brakeTorque = maxBrakeTorque;
            RRCollider.brakeTorque = maxBrakeTorque;
            FLCollider.brakeTorque = maxBrakeTorque;
            FRCollider.brakeTorque = maxBrakeTorque;

            // Release the accelerator when braking.
            RLCollider.motorTorque = 0f;
            RRCollider.motorTorque = 0f;
        }
        else
        {
            // Release the brakes when not braking.
            RLCollider.brakeTorque = 0f;
            RRCollider.brakeTorque = 0f;
            FLCollider.brakeTorque = 0f;
            FRCollider.brakeTorque = 0f;

            // Apply motor torque to rear wheels when not braking.
            RLCollider.motorTorque = carAccel * maxTorque;
            RRCollider.motorTorque = carAccel * maxTorque;
        }

        // Apply steering angle to front wheels
        FLCollider.steerAngle = carSteer * maxSteerAngle;
        FRCollider.steerAngle = carSteer * maxSteerAngle;
    }
}
