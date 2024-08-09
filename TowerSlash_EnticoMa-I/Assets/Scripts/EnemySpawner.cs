using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public float initSpawnSecs;
    public float dashSpawnSecs;
    public float currSpawnSecs;

    [SerializeField]
    public GameObject[] enemy;

    void Start()
    {
        GameManager.Instance.spawner = this;

        currSpawnSecs = initSpawnSecs;
        dashSpawnSecs = 0.5f;

        StartCoroutine(CO_Spawner());
    }

    void Update()
    {
        
    }

    private IEnumerator CO_Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(currSpawnSecs);
            SpawnEnemy();
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length - 1)], transform.position, transform.rotation);
    }
}
