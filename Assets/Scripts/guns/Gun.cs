using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform canyon;

    [SerializeField] GunsSO gunSciptableObject;
    GameObject bullet;
    float fireRate, bulletSpeed;
    Color color;

    Vector3 aimPoint;
    GameObject currentBullet;
    float shootTimer;
    bool shooting;

    private void Start()
    {
        bullet = gunSciptableObject.bullet;
        fireRate = gunSciptableObject.fireRate;
        bulletSpeed = gunSciptableObject.bulletSpeed;
        color = gunSciptableObject.color;

        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = color;
        this.enabled = false;
    }
    protected void Update()
    {
        aimPoint = AimPoint.aimPointScript.aimPoint - canyon.position;
       
        if (shooting)
            FireRateTime();
        else
            Shoot();
    }
    protected virtual void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            aimPoint = aimPoint.normalized;
            currentBullet = Instantiate(bullet);
            currentBullet.transform.position = canyon.position;
            currentBullet.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * bulletSpeed, ForceMode.VelocityChange);

            shooting = true;
        }
    }
    protected virtual void FireRateTime()
    {
        if (shootTimer > (1 / fireRate))
        {
            shooting = false;
            shootTimer = 0;
        }
        else
            shootTimer += Time.deltaTime;
    }
}
