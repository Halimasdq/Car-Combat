using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;
    public float bulletForce = 50f;
    public float bulletLifetime = 3f;
    public float fireRate = 0.1f;

    private float lastFireTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        float currentTime = Time.time;
        if (currentTime - lastFireTime > fireRate)
        {
            lastFireTime = currentTime;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
            Destroy(bullet, bulletLifetime);
        }
    }
}