using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBase : MonoBehaviour
{
    public float timetoClear;

    private GameObject gunHolder;

    public void Start()
    {
        gunHolder = GameManager.Instance.gunHolder;

        if(gunHolder.GetComponentInChildren<GunBase>().name == "pistol")
        {
            timetoClear = 2;
        }
        else if (gunHolder.GetComponentInChildren<GunBase>().name == "shotgun")
        {
            timetoClear = 1;
        }
        else if (gunHolder.GetComponentInChildren<GunBase>().name == "semi")
        {
            timetoClear = 0.5f;
        }
        StartCoroutine(Remove());
    }

    // destroys self after not getting picked up
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(timetoClear);
        Destroy(this.gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "Collisions")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
