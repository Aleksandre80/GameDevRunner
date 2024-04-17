using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = transform.forward * bulletSpeed;
            }
        }
    }
}
