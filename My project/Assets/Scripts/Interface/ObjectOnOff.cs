using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOff : MonoBehaviour
{
    public GameObject[] OnObjects;
    public GameObject[] Offobjects;
    public GameObject[] AllObjects;
    public void On()
    {
        for(int i=0; i<OnObjects.Length; i++)
        {
            OnObjects[i].gameObject.SetActive(true);
        }
    }

    public void Off()
    {
        for (int i = 0; i < Offobjects.Length; i++)
        {
            Offobjects[i].gameObject.SetActive(false);
        }
    }

    public void OnOff()
    {
        for (int i = 0; i < AllObjects.Length; i++)
        {
            if (AllObjects[i].activeSelf == true)
            {
                AllObjects[i].gameObject.SetActive(false);
            }
            else
            {
                AllObjects[i].gameObject.SetActive(true);
            }
        }
    }
}
