using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    Vector2 startTapPos;
    Vector2 endTapPos;

    //[SerializeField] one way to expose variables without making them public (so its like protected?)
    //[SerializeField] expose to editor only (so yes just like protected from Unreal in a way)
    [SerializeField] float tapRange = 10;

    public bool swipeUp = false;
    public bool swipeDown = false;
    public bool swipeLeft = false;
    public bool swipeRight = false;

    void Start()
    {
        GameManager.Instance.input = this;
    }

    // Update is called once per frame
    void Update()
    {
        ResetBool();
#if UNITY_EDITOR
        DesktopInput();
#elif UNITY_ANDROID
        AndriodInput();
#endif
    }

    public void DesktopInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTapPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 vector = (Vector2)Input.mousePosition - startTapPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTapPos = Input.mousePosition;

            Vector2 vector = endTapPos - startTapPos;

            if (vector.magnitude > tapRange)
            {
                Swipe(vector);
            }
            else
            {
                Tap();
            }
        }
    }

    void AndriodInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) // equivalent to GetMouseButtonDown
            {
                startTapPos = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended) // equivalent to GetMouseButtonUp
            {
                endTapPos = Input.GetTouch(0).position;

                Vector2 vector = endTapPos - startTapPos;

                if (vector.magnitude > tapRange)
                {
                    Swipe(vector);
                }
                else
                {
                    Tap();
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved) // equivalent to GetMouseButton
            {
                Vector2 vector = Input.GetTouch(0).position - startTapPos;
            }
        }
    }

    public void Swipe(Vector2 vec)
    {
        if (vec.y > tapRange) // swipe up
        {
            swipeUp = true;
        }
        else if (vec.x > tapRange) // swipe right
        {
            swipeRight = true;
        }
        else if (vec.y < -tapRange) // swipe down
        {
            swipeDown = true;
        }
        else if (vec.x < -tapRange) // swipe left
        {
            swipeLeft = true;
        }
    }

    public void Tap()
    {
        Debug.Log("Tap");
    }

    void ResetBool()
    {
        swipeUp = false;
        swipeDown = false;
        swipeLeft = false;
        swipeRight = false;
    }
}
