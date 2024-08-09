using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYellowArrow : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField]
    private GameObject[] greenArrows;
    public GameObject greenArrow;

    [SerializeField]
    private GameObject[] yellowArrows;
    private GameObject yellowArrow;

    private bool inRange = false;

    void Start()
    {
        
        greenArrow = Instantiate(greenArrows[Random.Range(0, greenArrows.Length - 1)], transform.position, transform.rotation);
        greenArrow.transform.parent = this.transform;
        greenArrow.SetActive(false);
        
        yellowArrow = Instantiate(yellowArrows[Random.Range(0, yellowArrows.Length - 1)], transform.position, transform.rotation);
        yellowArrow.transform.parent = this.transform;

        StartCoroutine(CO_rotate());
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.name == "ArrowRandStop")
        {
            inRange = true;
            greenArrow.SetActive(true);
            yellowArrow.SetActive(false);
        }
    }

    private IEnumerator CO_rotate()
    {
        while(!inRange)
        {
            yield return new WaitForSeconds(0.2f);
            yellowArrow.transform.Rotate(new Vector3(0, 0, 90));
        }    
    }

}
