using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject semi;
    public GameObject gunHolder;

    public TextMeshProUGUI playerCurrHealth;
    public TextMeshProUGUI playerMaxHealth;

    public TextMeshProUGUI ammoStockSemi;
    public TextMeshProUGUI ammoActiveSemi;
    public TextMeshProUGUI ammoStockPistol;
    public TextMeshProUGUI ammoActivePistol;
    public TextMeshProUGUI ammoStockShotgun;
    public TextMeshProUGUI ammoActiveShotgun;

    public Button refillPistol;
    public Button refillShotgun;
    public Button refillSemi;

    void Start()
    {
        refillPistol.gameObject.SetActive(false);
        refillShotgun.gameObject.SetActive(false);
        refillSemi.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        //playerCurrHealth.text = GameManager.Instance.player.HP.currHP.ToString();
        //playerMaxHealth.text = GameManager.Instance.player.HP.maxHP.ToString();

        // check for ammo - must be from the player, not from this hud
        ammoActiveSemi.text = semi.GetComponent<GunSemi>().currAmmo.ToString();
        ammoStockSemi.text = semi.GetComponent<GunSemi>().reserveAmmo.ToString();

        ammoActivePistol.text = pistol.GetComponent<GunPistol>().currAmmo.ToString();
        ammoStockPistol.text = pistol.GetComponent<GunPistol>().reserveAmmo.ToString();

        ammoActiveShotgun.text = shotgun.GetComponent<GunShotgun>().currAmmo.ToString();
        ammoStockShotgun.text = shotgun.GetComponent<GunShotgun>().reserveAmmo.ToString();

        // checks if curr ammo is less <=0
        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "pistol")
        {
            if(gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo <= 0)
            {
                refillPistol.gameObject.SetActive(true);
            }
        }

        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "shotgun")
        {
            if(gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo <= 0)
            {
                refillShotgun.gameObject.SetActive(true);
            }
        }

        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "semi")
        {
            if(gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo <= 0)
            {
                refillSemi.gameObject.SetActive(true);
            }
        }

        // checks if curr ammo is less >0
        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "pistol")
        {
            if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo > 0)
            {
                refillPistol.gameObject.SetActive(false);
            }
        }

        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "shotgun")
        {
            if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo > 0)
            {
                refillShotgun.gameObject.SetActive(false);
            }
        }

        if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().name == "semi")
        {
            if (gunHolder.GetComponent<WeaponSwitch>().currGun.GetComponentInChildren<GunBase>().currAmmo > 0)
            {
                refillSemi.gameObject.SetActive(false);
            }
        }
    }
}

