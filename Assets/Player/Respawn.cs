using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Respawn : MonoBehaviour
{
    public float respawnTime = 2f;
    public GameObject trackBoundaryGameObject;
    private NavMeshObstacle navMeshObstacle;

    private Rigidbody carRigidbody;
    private Transform respawnPoint;

    public bool isOffTrack = false;

    //@TODO
    //get all the respawn points in the map
    // set the current respawn point for the player
    // player distance - respawn point  = shortest distance -> set as current respawn point

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        navMeshObstacle = trackBoundaryGameObject.GetComponent<NavMeshObstacle>();
    }

    /*void Update()
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
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            respawnPoint = other.transform;
        }

        Debug.Log("Respawn Point Added");
    }

    public void PerformRespawn()
    {
        // Reset the car's position and velocity to the initial state
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;

        transform.position = respawnPoint.position;

        Debug.Log("Car respawned!");
    }
}