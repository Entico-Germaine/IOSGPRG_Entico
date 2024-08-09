using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // set min and max pickup
    protected int maxAmmo;
    protected int minAmmo;

    protected bool isPistolAmmo;
    protected bool isShotgunAmmo;
    protected bool isSemiAmmo;

    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        int randItem = Random.Range(minAmmo, maxAmmo);

        if (collision.gameObject.GetComponentInChildren<UnitBase>())
        {
            if(collision.gameObject.GetComponent<UnitPlayer>())
            {
                if (isSemiAmmo == true)
                {
                    GameManager.Instance.gunHolder.GetComponentInChildren<GunSemi>(true).AddAmmo(randItem);
                }
                else if (isPistolAmmo == true)
                {
                    GameManager.Instance.gunHolder.GetComponentInChildren<GunPistol>(true).AddAmmo(randItem);
                }
                else if (isShotgunAmmo == true)
                {
                    GameManager.Instance.gunHolder.GetComponentInChildren<GunShotgun>(true).AddAmmo(randItem);
                }
            }
            
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(3);
    }


}
