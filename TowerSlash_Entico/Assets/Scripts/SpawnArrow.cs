using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject[] greenArrows;
    public GameObject greenArrow;

    [SerializeField]
    private GameObject[] redArrows;
    public GameObject redArrow;

    [SerializeField]
    private GameObject[] yellowArrows;
    private GameObject yellowArrow;

    private GameObject arrow;
    public Direction killCondition;

    private bool inRange = false;
    private bool isYellow = false;
    private int randSpawn;

    void Start()
    {
        GameManager.Instance.arrow = this;

        randSpawn = Random.Range(0, 3);
        killCondition = Direction.Null;
        inRange = false;

        // instantiate Green Arrow
        if(randSpawn == 0)
        {
            SpawnGreen();
        }
        // instantiate Red Arrow
        if(randSpawn == 1)
        {
            SpawnRed();
        }

        // instantiates Yellow Arrow
        if(randSpawn == 2)
        {
            SpawnYellow();
            isYellow = true;

            StartCoroutine(CO_rotate());
        }
    }

    private void Update()
    {
        Debug.Log(inRange);
        //put in game manager
        if (GameManager.Instance.input.swipeDir == killCondition
                && inRange == true)
        {
            Debug.Log("Killed");
            GameManager.Instance.enemy.DestroyEnemy();
        }
    }

    void SpawnGreen()
    {
        greenArrow = Instantiate(greenArrows[Random.Range(0, greenArrows.Length - 1)], transform.position, transform.rotation);
        greenArrow.transform.parent = this.transform;
        arrow = greenArrow;
    }

    void SpawnRed()
    {
        redArrow = Instantiate(redArrows[Random.Range(0, redArrows.Length - 1)], transform.position, transform.rotation);
        redArrow.transform.parent = this.transform;
        arrow = redArrow;
    }

    void SpawnYellow()
    {
        yellowArrow = Instantiate(yellowArrows[Random.Range(0, yellowArrows.Length - 1)], transform.position, transform.rotation);
        yellowArrow.transform.parent = this.transform;
    }

    Direction KillCondition()
    {
        if (arrow.name == "arrowGreen_Down(Clone)" || arrow.name == "arrowRed_Up(Clone)")
        {
            return Direction.Down;
        }
        if (arrow.name == "arrowGreen_Up(Clone)" || arrow.name == "arrowRed_Down(Clone)")
        {
            return Direction.Up;
        }
        if (arrow.name == "arrowGreen_Left(Clone)" || arrow.name == "arrowRed_Right(Clone)")
        {
            return Direction.Left;
        }
        if (arrow.name == "arrowGreen_Right(Clone)" || arrow.name == "arrowRed_Left(Clone)")
        {
            return Direction.Right;
        }
        else
        {
            return Direction.Null;
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.name == "InputTrigger")
        {
            inRange = true;

            if(isYellow == true)
            {
                yellowArrow.SetActive(false);
                SpawnGreen();
            }

            killCondition = KillCondition();

            Debug.Log(killCondition);
        }
    }

    private IEnumerator CO_rotate()
    {
        while (!inRange)
        {
            yield return new WaitForSeconds(0.2f);
            yellowArrow.transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
