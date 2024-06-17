using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform spawner;

    public int initSpeed;
    public int currSpeed;
    private bool isWithinRange = false;

    void Start()
    {
        GameManager.Instance.enemy = this;

        initSpeed = 3;
        currSpeed = initSpeed;
    }

    void Update()
    {
        transform.Translate(currSpeed * Vector3.down * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
