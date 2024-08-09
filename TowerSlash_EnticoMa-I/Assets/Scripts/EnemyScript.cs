using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] arrow;

    private Transform spawner;
    private GameObject spawnedArrow;
    public GameObject gArrow;
    public int initSpeed;
    public int currSpeed;
    public int dashSpeed;
    private bool isWithinRange = false;
    private string killCondition;

    private float rand;
    private float chanceTotal;
    private float chanceMarker;
    private float killPoint;

    void Start()
    {
        GameManager.Instance.enemy = this;

        spawner = transform.Find("ArrowSpawner");
        spawnedArrow = Instantiate(arrow[Random.Range(0, arrow.Length)], spawner.position, spawner.rotation);
        spawnedArrow.transform.parent = this.transform;

        if(spawnedArrow.name == "arrowGreen_Down(Clone)" || spawnedArrow.name == "arrowRed_Up(Clone)")
        {
            killCondition = "down";
        }
        if (spawnedArrow.name == "arrowGreen_Up(Clone)" || spawnedArrow.name == "arrowRed_Down(Clone)")
        {
            killCondition = "up";
        }
        if (spawnedArrow.name == "arrowGreen_Left(Clone)" || spawnedArrow.name == "arrowRed_Right(Clone)")
        {
            killCondition = "left";
        }
        if (spawnedArrow.name == "arrowGreen_Right(Clone)" || spawnedArrow.name == "arrowRed_Left(Clone)")
        {
            killCondition = "right";
        }

        initSpeed = 3;
        currSpeed = initSpeed;
        dashSpeed = 10;
        chanceTotal = 100;
        chanceMarker = chanceTotal * 0.03f;
        killPoint = 3;
    }

    void Update()
    {
        transform.Translate(currSpeed * Vector3.down * Time.deltaTime);

        if(isWithinRange == true)
        {
            DestroyConditions();
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.name == "AttackRange")
        {
            isWithinRange = true;

            if (spawnedArrow.name == "arrowYellow(Clone)")
            {
                gArrow = this.gameObject.transform.GetChild(1).GetComponent<RotateYellowArrow>().greenArrow;
                spawnedArrow = gArrow;

                if (spawnedArrow.name == "arrowGreen_Down(Clone)")
                {
                    killCondition = "down";
                }
                if (spawnedArrow.name == "arrowGreen_Up(Clone)")
                {
                    killCondition = "up";
                }
                if (spawnedArrow.name == "arrowGreen_Left(Clone)")
                {
                    killCondition = "left";
                }
                if (spawnedArrow.name == "arrowGreen_Right(Clone)")
                {
                    killCondition = "right";
                }
            }
        }
        if (otherObject.name == "PlayerCharacter")
        {
            Destroy(gameObject);
            GameManager.Instance.player.TakeDamageFromEnemy();
        }
    }

    void DestroyConditions()
    {
        if(GameManager.Instance.input.swipeDown == true && killCondition == "down")
        {
            OnKill();
        }
        if (GameManager.Instance.input.swipeUp == true && killCondition == "up")
        {
            OnKill();
        }
        if (GameManager.Instance.input.swipeLeft == true && killCondition == "left")
        {
            OnKill();
        }
        if (GameManager.Instance.input.swipeRight == true && killCondition == "right")
        {
            OnKill();
        }
    }

    void OnKill()
    {
        Debug.Log("Enemy Slashed");

        GameManager.Instance.player.GetDashPoints();

        rand = Random.Range(0, chanceTotal);
        if(rand <= chanceMarker)
        {
            GameManager.Instance.player.GetHealth();
        }

        GameManager.Instance.player.totalScore += killPoint;

        Destroy(gameObject);
    }
}
