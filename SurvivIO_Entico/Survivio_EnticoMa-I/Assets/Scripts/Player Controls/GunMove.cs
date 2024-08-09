using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{

    [SerializeField]
    public GameObject gunHolder;

    [SerializeField]
    public Joystick joystickLook;

    void Start()
    {
        gunHolder.transform.rotation = Quaternion.Euler(0, 0, gunHolder.transform.rotation.z + 45);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 aimVector = (Vector3.up * joystickLook.Horizontal + Vector3.left * joystickLook.Vertical);
        if (joystickLook.Horizontal != 0 || joystickLook.Vertical != 0)
        {
            gunHolder.transform.rotation = Quaternion.LookRotation(Vector3.forward, aimVector);
        }
        //else
        //{
        //    gunHolder.transform.rotation = Quaternion.Euler(0, 0, gunHolder.transform.rotation.z + 45);
        //}

    }
}
