using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Null
}
public class InputSwipe : MonoBehaviour
{
    [SerializeField] Vector2 startPos = Vector2.zero;
    [SerializeField] Vector2 endPos = Vector2.zero;
    [SerializeField] float startDur = 0.0f;
    [SerializeField] float endDur = 0.0f;
    [SerializeField] float currDur = 0.0f;

    float minSwipeDist = 50.0f;
    float maxSwipeDur = 0.3f;

    [SerializeField] 
    public Direction swipeDir = Direction.Null;

    void Start()
    {
        GameManager.Instance.input = this;
    }

    void Update()
    {
#if UNITY_EDITOR_WIN
        MouseUpdate();
#elif UNITY_ANDROID
        TouchUpdate();
#endif
    }

    void TouchUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    SwipeStart(touch.position, Time.time);
                    break;
                case TouchPhase.Ended:
                    SwipeEnd(touch.position, Time.time);
                    break;
            }

            Invoke("Reset", 0.2f);
        }
    }

    void MouseUpdate()
    {
        // Start Pos
        if (Input.GetMouseButtonDown(0))
        {
            SwipeStart(Input.mousePosition, Time.time);
        }
        // End Pos
        if (Input.GetMouseButtonUp(0))
        {
            SwipeEnd(Input.mousePosition, Time.time);
            Invoke("Reset", 0.2f);
        }
    }

    void SwipeStart(Vector2 pos, float time)
    {
        startPos = pos;
        startDur = time;
    }

    void SwipeEnd(Vector2 pos, float time)
    {
        endPos = pos;
        endDur = time;

        DetectSwipe();
    }

    void DetectSwipe()
    {
        float swipeDist = Vector2.Distance(startPos, endPos);
        float swipeDur = endDur - startDur;

        if (swipeDist >= minSwipeDist
            && swipeDur <= maxSwipeDur)
        {
            Vector2 dir = (endPos - startPos).normalized;
            swipeDir = SwipeDirection(dir);
        }
    }

    Direction SwipeDirection(Vector2 dir)
    {
        float angle = Vector2.SignedAngle(Vector2.up, dir);

        if (angle < 45 && angle > -45)
        {
            //Debug.Log("input UP");
            return Direction.Up;
        }
        else if (angle < 135 && angle > 45)
        {
            //Debug.Log("input LEFT");
            return Direction.Left;
        }
        else if (angle < -136 || angle > 136)
        {
            //Debug.Log("input DOWN");
            return Direction.Down;
        }
        else if (angle < -45 && angle > -180)
        {
            //Debug.Log("input RIGHT");
            return Direction.Right;
        }

        return Direction.Null;
    }

    void Reset()
    {
        swipeDir = Direction.Null;
    }
}
