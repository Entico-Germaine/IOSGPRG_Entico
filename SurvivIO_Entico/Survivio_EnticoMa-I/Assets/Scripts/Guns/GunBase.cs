using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public GameObject bullet;

    //public so the hud and pikcup can access
    // not the best solution but it works for now
    public new string name;

    public bool canShoot;
    public bool isOnCoolDown;
    public int reloadTime;
    public float fireRate;
    public float bulletSpeed;
    
    public int currAmmo;
    public int reserveAmmo;
    public int maxClip;

    private void Start()
    {
        canShoot = true;
    }

    public void FixedUpdate()
    {
        if (currAmmo <= 0)
        {
            canShoot = false;
        }
        else if (currAmmo > 0)
        {
            canShoot = true;
        }
    }

    virtual public void Fire()
    {
        if (canShoot == true)
        {
            GameObject bulletForce = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletForce.GetComponent<Rigidbody2D>().AddForce(bulletForce.transform.right * bulletSpeed);

            currAmmo--;
        }
    }
    public void AddAmmo(int ammoNumber)
    {
        reserveAmmo += ammoNumber;

        if (reserveAmmo > 100)
        {
            reserveAmmo = 100;
        }
    }

    virtual public void RefillClip()
    {
        int refill = maxClip - currAmmo;

        if (reserveAmmo - refill < 0)
        {
            currAmmo += reserveAmmo;
            reserveAmmo = 0;
        }
        else
        {
            currAmmo += refill;
            reserveAmmo -= refill;
        }

        // catcher
        if(reserveAmmo <= 0)
        {
            reserveAmmo = 0;
        }
    }
}
