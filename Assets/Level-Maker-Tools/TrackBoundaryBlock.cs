using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBoundaryBlock : MonoBehaviour
{

    float collisionTimer = 0;
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("hit!!");

        if (collision.transform.CompareTag("Player"))
        {
            collisionTimer += Time.deltaTime;
            Debug.Log($"collision Timer {collisionTimer}");
            // if it is in the collider for longer than 10 seconds
            if
                (collisionTimer > 10)
            {
                // car is stuck on the boundary
                // respawn
                collision.transform.GetComponent<Respawn>().PerformRespawn();

                // reset timer
                collisionTimer = 0;
            }
        }
    }

}
