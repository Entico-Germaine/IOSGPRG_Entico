using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPistol : GunBase
{
    private void Awake()
    {
        name = "pistol";
    }

    public override void RefillClip()
    {
        base.RefillClip();

        //GameManager.Instance.hud.refillPistol.gameObject.SetActive(false);
    }
}
