using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject obj;
    public Transform aimPoint;
    public float bulletSpeed;
    private float reloadDelay = 1f;

    private float currentDelay = 1f;
    private bool canShoot = true;

    private void Start()
    {
        bulletSpeed = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
        
            if (canShoot)
            {
                canShoot = false;
                currentDelay = reloadDelay;
                Shoot();
            }
        
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, aimPoint.position, aimPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-aimPoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
