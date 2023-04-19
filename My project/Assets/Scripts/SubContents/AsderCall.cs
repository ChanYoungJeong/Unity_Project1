using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class AsderCall : MonoBehaviour
{
    public Button AsderButton;
    GetAsderBead Getasderbead;
    public Transform PlayerTrans;
    private Joystick joystick;
    public GameObject SubAsder;

    public float y;
    public int BeadCount;
    public float DestroyCount;
   
    
    private void Awake()
    {
        if (GameObject.Find("joystickBG"))
        {
            joystick = GameObject.FindObjectOfType<Joystick>();
        }
    }
    private void Update()
    {
        OnOffAsderButton();
    }

    public void OnOffAsderButton()
    {
        if (BeadCount > 0)
        {
            AsderButton.interactable = true;
        }
        else
            AsderButton.interactable = false;
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

            Destroy(Asder,DestroyCount);
        }
       
        BeadCount--;
    }
}