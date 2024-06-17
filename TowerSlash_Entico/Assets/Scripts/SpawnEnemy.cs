using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    public float initSpawnSecs;
    public float currSpawnSecs;

    [SerializeField]
    public GameObject[] enemy;

    void Start()
    {
        currSpawnSecs = initSpawnSecs;

        StartCoroutine(CO_Spawner());
    }

    void Update()
    {

    }

    void SpawnEnemies()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length - 1)], transform.position, transform.rotation);
    }

    private IEnumerator CO_Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(currSpawnSecs);
            SpawnEnemies();
        }

    }
}
