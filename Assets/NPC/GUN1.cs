using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN1 : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 10f;
    public float fireRate = 1.0f; // Adjust the fire rate as needed
    private float nextFireTime = 0.0f;

    bool isInTrigger = false;

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime && isInTrigger == true)
        {
            // Fire the bomb
            ThrowBomb();

            // Update the next fire time
            nextFireTime = Time.time + fireRate;
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        bombRigidbody.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
