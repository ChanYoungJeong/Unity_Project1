using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsderCall : MonoBehaviour
{
    private Joystick joystick;
    public GameObject SubAsder;
    public float y;


    private void Awake()
    {
        if (GameObject.Find("joystickBG"))
        {
            joystick = GameObject.FindObjectOfType<Joystick>();
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (joystick.Horizontal > 0)
                {
                    y = 180;
                }
                else
                {
                    y = 0;
                }
                GameObject archerAsder = Instantiate(SubAsder, transform.position + Vector3.right * 1.0f, Quaternion.identity);
                archerAsder.transform.rotation = Quaternion.Euler(0, y, 0);
            }
        }
    }
}