using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderData;

public class AsderCall : MonoBehaviour
{
    GetAsderBead Getasderbead;
    public Transform PlayerTrans;
    private Joystick joystick;
    public GameObject SubAsder;
    public float y;
    public int BeadCount;
   
    
    private void Awake()
    {
        if (GameObject.Find("joystickBG"))
        {
            joystick = GameObject.FindObjectOfType<Joystick>();
        }
    }
  
    public void CallAsder()
    {
        if (BeadCount > 0)
        {
            /*if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (joystick.Horizontal > 0)
                {
                    y = 180;
                }
                else
                {
                    y = 0;
                }
            }*/

                GameObject Asder = Instantiate(SubAsder, PlayerTrans.position + Vector3.right * 1.0f, Quaternion.identity);
                Asder.transform.rotation = Quaternion.Euler(0, y, 0);
            
            BeadCount--;
        }
    }
}