using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotgun : GunBase
{
    public float bulletSpread;

    private void Awake()
    {
        name = "shotgun";
    }
    public override void Fire()
    {
        if (canShoot == true)
        {
            for(int i = 0; i < 4; i++)
            {
                GameObject bulletForce = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRB = bulletForce.GetComponent<Rigidbody2D>();
                Vector2 dir = transform.rotation * Vector2.right;
                Vector2 sDir = Vector2.Perpendicular(dir) * Random.Range(-bulletSpread, bulletSpread);
                bulletRB.velocity = (dir + sDir) * bulletSpeed;
            }

            currAmmo--;
        }
        if (currAmmo <= 0)
        {
            canShoot = false;
        }
    }

    public override void RefillClip()
    {
        base.RefillClip();

        //GameManager.Instance.hud.refillShotgun.gameObject.SetActive(false);
    }
}
