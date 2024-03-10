using UnityEngine;
using System.Collections;

public class NPCWeaponController : MonoBehaviour
{
    public GameObject balloonBulletPrefab;  // Reference to the visual representation of the bullet
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;  // Adjust the fire rate as needed
    public float firingRange = 10f;  // Specify the firing range

    private void Start()
    {
        StartCoroutine(AutoFireBalloons());
    }

    private IEnumerator AutoFireBalloons()
    {
        while (true)  // Infinite loop for continuous firing
        {
            // Detect nearby cars within the firing range
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, firingRange, LayerMask.GetMask("Cars"));  // Assuming the cars are on the "Cars" layer

            // Fire at nearby cars within range
            foreach (Collider collider in nearbyColliders)
            {
                if (collider.CompareTag("Car"))  // Assuming the cars have a tag named "Car"
                {
                    FireBalloonBullet(collider.transform);
                }
            }

            yield return new WaitForSeconds(fireRate);  // Wait for the specified fire rate before checking for nearby cars again
        }
    }

    private void FireBalloonBullet(Transform target)
    {
        // Instantiate the balloon-like bullet and aim it at the target car
        GameObject bullet = Instantiate(balloonBulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(target.position - bulletSpawnPoint.position));
        // Optionally, you can apply additional customization to the balloon bullet, such as setting its speed or other properties
    }
}
