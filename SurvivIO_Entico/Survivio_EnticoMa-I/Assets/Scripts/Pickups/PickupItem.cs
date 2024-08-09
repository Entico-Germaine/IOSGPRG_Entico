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
            // collision.AddAmmoToPlayer()
            Debug.Log(randItem.ToString());
            Debug.Log(isPistolAmmo);
            Debug.Log(isShotgunAmmo);
            Debug.Log(isSemiAmmo);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(3);
    }


}
