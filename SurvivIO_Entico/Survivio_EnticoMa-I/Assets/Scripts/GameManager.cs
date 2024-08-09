using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public PickupItem pickupItem;
    public UnitPlayer player;
    public SpawnLoot spawnerLoot;
    public GunBase gunBase;
    public HUD hud;

    public GameObject gunHolder;

    void Start()
    {
        gunHolder = GameObject.Find("Player/GunHolder");
    }


    void Update()
    {

    }
}