using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSemi : GunBase
{
    public float timeBetweenBullets = 0.2f;
    public int bulletsInSeries = 3;
    public int timeBetweenSeries = 1;

    private void Awake()
    {
        name = "semi";
    }

    public override void Fire()
    {
        if (canShoot == true)
        {
            if (isOnCoolDown == false)
            {
                StartCoroutine(SemiShootCoroutine());
                isOnCoolDown = true;
            }
            else if(isOnCoolDown)
            {
                StartCoroutine(SemiCoolDown());
                isOnCoolDown = false;
            }

        }

        if (currAmmo <= 0)
        {
            currAmmo = 0;
            canShoot = false;
        }
    }

    IEnumerator SemiShootCoroutine()
    {
        int i = 0;
        while (i < bulletsInSeries)
        {
            if (canShoot == false)
            {
                break;
            }

            GameObject bulletForce = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletForce.GetComponent<Rigidbody2D>().AddForce(bulletForce.transform.right * bulletSpeed);
            currAmmo--;

            yield return new WaitForSeconds(timeBetweenBullets);
        }
    }

    IEnumerator SemiCoolDown()
    {
        yield return new WaitForSeconds(timeBetweenSeries);
    }

    public override void RefillClip()
    {
        base.RefillClip();

        //GameManager.Instance.hud.refillSemi.gameObject.SetActive(false);
    }
}
