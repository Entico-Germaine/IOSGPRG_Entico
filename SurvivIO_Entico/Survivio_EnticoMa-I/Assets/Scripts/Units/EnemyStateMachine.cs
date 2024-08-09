using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyPhase
{
    Idle, 
    Patrol,
    Chase,
}

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyPhase currState;
    //private GameObject gun;

    public Transform target { get; set; }

    private void Start()
    {
        //gun = GetComponent<UnitEnemy>().enemyGun;
        //Debug.Log(gun.name);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case EnemyPhase.Idle: IdleUpdate(); break;
            case EnemyPhase.Patrol: PatrolUpdate(); break;
            case EnemyPhase.Chase: ChaseUpdate(); break;
        }
    }

    private float countdown = 0;
    private float countMax = 5;
    private float countMin = 3;
    private float waitTime = 1;

    void IdleUpdate()
    {
        if (target != null)
        {
            currState = EnemyPhase.Chase;
            countdown = 0;
            return;
        }

        countdown += Time.deltaTime;

        if (waitTime < countdown)
        {
            countdown = 0;
            waitTime = Random.Range(countMin, countMax);
            currState = EnemyPhase.Patrol;
            return;
        }
    }

    private Vector2 targetPoint = Vector2.zero;
    private float patrolOffset = .5f;
    void PatrolUpdate()
    {
        if (target != null)
        {
            currState = EnemyPhase.Chase;
            targetPoint = Vector2.zero;
            return;
        }

        if (Vector2.zero == targetPoint)
        {
            targetPoint = RandomPatrolPoint();
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPoint, Time.deltaTime);
        if (Vector2.Distance(this.transform.position, targetPoint) < patrolOffset)
        {
            currState = EnemyPhase.Idle;
            targetPoint = Vector2.zero;
            return;
        }
    }

    Vector2 RandomPatrolPoint()
    {
        float pntX = (float)Random.Range(-12, 12);
        float pntY = (float)Random.Range(-6, 6);

        return new Vector2(pntX, pntY);
    }

    private float countUpShoot = 0;
    private float countMaxShoot = 5;
    private float countMinShoot = 1;
    private float waitTimeShoot = 1;
    void ChaseUpdate()
    {
        if (target == null)
        {
            currState = EnemyPhase.Idle;
            return;
        }

        Vector3 dir = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, -dir);

        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, this.GetComponentInChildren<UnitEnemy>().speed * Time.deltaTime);

        // prevents ai from spamming
        countUpShoot += Time.deltaTime;

        if (countUpShoot >= waitTimeShoot)
        {
            countUpShoot = 0;
            waitTimeShoot = Random.Range(countMinShoot, countMaxShoot);
            Shoot();
        }
    }

    void Shoot()
    {
        if(currState == EnemyPhase.Chase)
        {
            this.GetComponentInChildren<GunBase>().Fire();
        }  
    }
}
