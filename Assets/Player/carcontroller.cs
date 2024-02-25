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
    public float maxBrakeTorque = 3000f;
    public float maxSteerAngle = 30f;

    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 10f;

    private float carAccel;
    private float carSteer;

    void FixedUpdate()
    {
        carAccel = Input.GetAxis("Vertical");
        carSteer = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space)) // handbrake
        {
            float handbrakeTorque = maxBrakeTorque;

            RLCollider.brakeTorque = handbrakeTorque;
            RRCollider.brakeTorque = handbrakeTorque;
            FLCollider.brakeTorque = handbrakeTorque;
            FRCollider.brakeTorque = handbrakeTorque;

            RLCollider.motorTorque = 0f;
            RRCollider.motorTorque = 0f;
        }
        else
        {
            RLCollider.brakeTorque = 0f;
            RRCollider.brakeTorque = 0f;
            FLCollider.brakeTorque = 0f;
            FRCollider.brakeTorque = 0f;

            // Adjusted for sharper and smoother turning
            float turnFactor = 2f; // Adjust this value to control turning sensitivity
            FLCollider.steerAngle = carSteer * maxSteerAngle * turnFactor;
            FRCollider.steerAngle = carSteer * maxSteerAngle * turnFactor;

            RLCollider.motorTorque = carAccel * maxTorque;
            RRCollider.motorTorque = carAccel * maxTorque;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowBomb();
        }
    }
    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        bombRigidbody.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }
}
