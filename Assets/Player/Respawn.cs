using UnityEngine;

public class Respawn : MonoBehaviour
{
<<<<<<< Updated upstream
    public float respawnTime = 2f;
    private List<NavMeshObstacle> navMeshObstacles = new List<NavMeshObstacle>();

    private Rigidbody carRigidbody;
    private Transform respawnPoint;

    //public bool isOffTrack = false;

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
           // Debug.LogError("NavMeshObstacle not found on the specified GameObject.");
            return false; // Return false to avoid unintended behavior if NavMeshObstacle is not found
        }
    }
=======
    public Transform respawnPoint; // The checkpoint to respawn the car at
    public string roadObjectName = "Road1"; // The name of the road object
>>>>>>> Stashed changes

    private void OnTriggerEnter(Collider other)
    {
        // Check if the car has collided with the road object
        if (other.gameObject.name == Road1)
        {
            Debug.Log("Car is on the road.");
        }
        else
        {
            // If the car goes off-road, respawn it at the checkpoint
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.position;
                Debug.Log("Car respawned at checkpoint.");
            }
            else
            {
                Debug.LogWarning("Respawn point not set!");
            }
        }
    }
}
