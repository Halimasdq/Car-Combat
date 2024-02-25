using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Place holder for the spawn point
    public Transform respawnPoint;

    // Store the position of the car when it hits the outer surface
    private Vector3 lastCollisionPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //This fires off when the car hits the outer surface
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("OutOfBounds"))
        {
            // Store the position of the car
            lastCollisionPosition = col.transform.position;

            // Respawn the car
            col.transform.position = respawnPoint.position;
        }
    }

    //This fires off when the car hits the outer surface
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("OutOfBounds"))
        {
            // Store the position of the car
            lastCollisionPosition = col.transform.position;

            // Respawn the car
            col.transform.position = respawnPoint.position;
        }
    }

    //This fires off when the car is stuck on the boundary
    public void PerformRespawn(Vector3 position)
    {
        // Move the car to the stored position
        transform.position = position;
    }
}