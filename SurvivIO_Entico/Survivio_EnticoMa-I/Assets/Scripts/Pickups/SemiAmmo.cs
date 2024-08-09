using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAmmo : PickupItem
{
    private void Start()
    {
        isSemiAmmo = true;

        minAmmo = 10;
        maxAmmo = 50;
    }
}
