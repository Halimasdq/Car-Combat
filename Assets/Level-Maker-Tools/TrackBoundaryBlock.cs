using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint; // The checkpoint to respawn the car at
    public string roadObjectName = "Road1"; // The name of the road object

    private void OnTriggerEnter(Collider other)
    {
        // Check if the car has collided with the road object
        if (other.CompareTag(roadObjectName))
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
