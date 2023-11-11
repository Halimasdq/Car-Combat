using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Respawn : MonoBehaviour
{
    public float respawnTime = 2f;
    public GameObject trackBoundaryGameObject;

    private Rigidbody carRigidbody;
    private Transform respawnPoint;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        CreateRespawnPoint();
    }

    void Update()
    {
        // Check if the car is off the track
        if (IsOffTrack())
        {
            // Invoke the respawn function after the specified respawn time
            Invoke("PerformRespawn", respawnTime);
        }
    }

    bool IsOffTrack()
    {
        NavMeshObstacle navMeshObstacle = trackBoundaryGameObject.GetComponent<NavMeshObstacle>();

        if (navMeshObstacle != null)
        {
            // Check if the car's position is outside the obstacle's bounds
            Vector3 closestPoint = navMeshObstacle.transform.InverseTransformPoint(transform.position);
            return !navMeshObstacle.enabled || navMeshObstacle.size.magnitude < Mathf.Abs(closestPoint.y);
        }
        else
        {
            Debug.LogError("NavMeshObstacle not found on the specified GameObject.");
            return false; // Return false to avoid unintended behavior if NavMeshObstacle is not found
        }
    }

    void PerformRespawn()
    {
        // Reset the car's position and velocity to the initial state
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;

        // Set the respawn point to the current position of the car
        respawnPoint.position = transform.position;

        Debug.Log("Car respawned!");
    }

    void CreateRespawnPoint()
    {
        // Create an empty GameObject as the respawn point
        respawnPoint = new GameObject("RespawnPoint").transform;
    }
}