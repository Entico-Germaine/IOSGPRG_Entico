using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnEnemy;

    // change time later and randomize 
    private float startTime = 10;
    private float currTime;

    void Start()
    {
        // Make random items and locations
        Instantiate(spawnEnemy[0], this.transform);
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;

        if (currTime < 0)
        {
            Instantiate(spawnEnemy[0], this.transform);
            currTime = startTime;
        }
    }
}
