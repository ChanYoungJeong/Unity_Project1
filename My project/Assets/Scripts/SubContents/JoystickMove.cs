using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public float speed;
    private Joystick joystick;
    public GameObject effect;

    private void Awake()
    {
        if (GameObject.Find("joystickBG"))
        {
            joystick = GameObject.FindObjectOfType<Joystick>();
        }
    }

    private void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (joystick.Horizontal > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }

            MoveControl();
        }
/*        ////////////////////////////////////////////////////여기부터
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        if(dirX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

        Vector3 dirXY = Vector3.right * dirX + Vector3.up * dirY;
        if(dirXY != null)
        {

        }
        dirXY.Normalize();
        transform.position += dirXY * speed * Time.deltaTime;
        ///////////////////////////////////////////////////여기까지 임시*/
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;

        transform.position += upMovement;
        transform.position += rightMovement;

        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
