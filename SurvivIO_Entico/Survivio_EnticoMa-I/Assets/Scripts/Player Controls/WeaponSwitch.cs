using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private int weaponCount = 1;
    public int currIndex;

    [SerializeField]
    public GameObject[] guns;
    [SerializeField]
    public GameObject weaponHolder;
    public GameObject currGun;

    void Start()
    {
        weaponCount = weaponHolder.transform.childCount;
        guns = new GameObject[weaponCount];

        for (int i = 0; i < weaponCount; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currGun = guns[0];
        currIndex = 0;
    }

    // revisit for cleanup
    public void Pistol()
    {
        guns[currIndex].SetActive(false);
        currIndex = 0;
        guns[currIndex].SetActive(true);
        currGun = guns[currIndex];
    }

    public void Shotgun()
    {
        guns[currIndex].SetActive(false);
        currIndex = 1;
        guns[currIndex].SetActive(true);
        currGun = guns[currIndex];
    }
    public void Auto()
    {
        guns[currIndex].SetActive(false);
        currIndex = 2;
        guns[currIndex].SetActive(true);
        currGun = guns[currIndex];
    }
}
