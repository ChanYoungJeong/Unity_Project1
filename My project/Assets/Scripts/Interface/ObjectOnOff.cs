using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOff : MonoBehaviour
{
    public GameObject[] gameObjects;
    public void On()
    {
        this.gameObject.SetActive(true);
    }
    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void OnANDOff()
    {
        if (this.gameObject.activeSelf==false)
        {
            On();
        }
        else
        {
            Off();
        }
    }
}
