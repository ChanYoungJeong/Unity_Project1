using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public float speed;
    private Joystick joystick;

    private void Awake()
    {
        if (GameObject.Find("joystickBG"))
        {
            joystick = GameObject.FindObjectOfType<Joystick>();
        }
    }

    private void Update()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {

            if(joystick.Horizontal > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }

            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;

        transform.position += upMovement;
        transform.position += rightMovement;
    }
}
