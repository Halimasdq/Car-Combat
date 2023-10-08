using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;
    public float life = 3;

    void Start()
    {
        // Destroy the bullet after its 'life' seconds
        Destroy(gameObject, life);
    }

    void FixedUpdate()
    {
        // Move the bullet forward at a constant speed
        transform.Translate(Vector3.forward * bulletSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object that is not the gun
        if (!collision.gameObject.CompareTag("Gun"))
        {
            // Destroy the object the bullet collided with
            Destroy(collision.gameObject);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
