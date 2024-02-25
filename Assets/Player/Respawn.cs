using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Respawn : MonoBehaviour
{
    public float respawnTime = 2f;
    private List<NavMeshObstacle> navMeshObstacles = new List<NavMeshObstacle>();

    private Rigidbody carRigidbody;
    private Transform respawnPoint;

    public bool isOffTrack = false;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();

        // Find all objects with NavMeshObstacle components in the scene
        NavMeshObstacle[] obstacles = FindObjectsOfType<NavMeshObstacle>();

        // Add all found NavMeshObstacle components to the list
        foreach (NavMeshObstacle obstacle in obstacles)
        {
            navMeshObstacles.Add(obstacle);
        }

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

    NavMeshObstacle FindClosestObstacleToPlayer()
    {
        if (navMeshObstacles.Count == 0 || transform == null)
        {
            return null;
        }

        NavMeshObstacle closestObstacle = navMeshObstacles[0];
        float closestDistance = Vector3.Distance(navMeshObstacles[0].transform.position, transform.position);

        // Iterate through all obstacles to find the closest one to the player
        foreach (NavMeshObstacle obstacle in navMeshObstacles)
        {
            float distance = Vector3.Distance(obstacle.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestObstacle = obstacle;
                closestDistance = distance;
            }
        }

        return closestObstacle;
    }

    bool IsOffTrack()
    {

        NavMeshObstacle closestObstacle = FindClosestObstacleToPlayer();

        if(closestObstacle != null)
        {
            /* // Check if the car's position is outside the obstacle's bounds
             Vector3 closestPoint = closestObstacle.transform.InverseTransformPoint(transform.position);
             return !closestObstacle.enabled || closestObstacle.size.magnitude < Mathf.Abs(closestPoint.y);*/

            return false;
        }  
        else
        {
            Debug.LogError("NavMeshObstacle not found on the specified GameObject.");
            return false; // Return false to avoid unintended behavior if NavMeshObstacle is not found
        }
    }

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