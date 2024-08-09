using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : PickupItem
{
    private void Start()
    {
        isPistolAmmo = true;

        minAmmo = 5;
        maxAmmo = 7;
    }
}
