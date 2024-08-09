using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEnemy : UnitBase
{
    public GameObject enemyGun;
    [SerializeField]
    public GameObject gunPlace;

    // Start is called before the first frame update
    void Start()
    {
        enemyGun = Instantiate(gunArray[Random.Range(0, gunArray.Length-1)], gunPlace.transform.position, gunPlace.transform.rotation, gunPlace.transform);
        enemyGun.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

        enemyGun.SetActive(true);
    }
}
