using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnLoot;

    // change time later and randomize 
    private float startTime = 10;
    private float currTime;

    void Start()
    {
        // Make random items and locations
        Instantiate(spawnLoot[Random.Range(0, spawnLoot.Length)], this.transform);
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;

        if (currTime < 0)
        {
            Instantiate(spawnLoot[Random.Range(0, spawnLoot.Length)], this.transform);
            currTime = startTime;
        }
    }
}
