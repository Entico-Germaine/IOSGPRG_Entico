using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : PickupItem
{
    private void Start()
    {
        isShotgunAmmo = true;

        minAmmo = 1;
        maxAmmo = 2;
    }
}
