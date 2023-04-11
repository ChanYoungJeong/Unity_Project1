using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectOff : MonoBehaviour
{
    public GameObject[] Objects;
    void Start()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].gameObject.SetActive(false);
        }
    }
    public void Off()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].gameObject.SetActive(false);
        }
    }

}
