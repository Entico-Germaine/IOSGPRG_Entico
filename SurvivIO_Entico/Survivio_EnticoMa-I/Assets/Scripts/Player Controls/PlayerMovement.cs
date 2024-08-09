using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    [SerializeField]
    private Rigidbody2D playerUnit;

    [SerializeField]
    public Joystick joystickMovement;

    private Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        movement.x = joystickMovement.Horizontal;
        movement.y = joystickMovement.Vertical;
    }

    private void FixedUpdate()
    {
        playerUnit.MovePosition(playerUnit.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
