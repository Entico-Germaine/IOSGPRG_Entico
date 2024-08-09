using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public TouchInput input;
    public EnemyScript enemy;
    public PlayerScript player;
    public EnemySpawner spawner;
    public HUD hud;

    void Start()
    {
        
    }

    
    void Update()
    {

    }
}
