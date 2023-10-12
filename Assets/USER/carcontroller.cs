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

    void Update()
    {
        carAccel = Input.GetAxis("Vertical");
        carSteer = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.Space))
        {
            RLCollider.brakeTorque = maxBrakeTorque;
            RRCollider.brakeTorque = maxBrakeTorque;
            FLCollider.brakeTorque = maxBrakeTorque;
            FRCollider.brakeTorque = maxBrakeTorque;

            RLCollider.motorTorque = 0f;
            RRCollider.motorTorque = 0f;
        }
        else
        {
            RLCollider.brakeTorque = 0f;
            RRCollider.brakeTorque = 0f;
            FLCollider.brakeTorque = 0f;
            FRCollider.brakeTorque = 0f;

            RLCollider.motorTorque = carAccel * maxTorque;
            RRCollider.motorTorque = carAccel * maxTorque;
        }

        FLCollider.steerAngle = carSteer * maxSteerAngle;
        FRCollider.steerAngle = carSteer * maxSteerAngle;

        // Check if a key (e.g., "F") is pressed to throw a bomb.
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
