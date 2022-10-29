using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharSetting : MonoBehaviour
{
    public GameObject panel;


    private void Start()
    {
        panel.SetActive(false);
    }

    public void SetActiveCharStatPanel()
    {
        if(panel.activeSelf == false)
        {
            Debug.Log("hello");
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

}
