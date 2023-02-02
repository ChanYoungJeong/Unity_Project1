using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharUI : MonoBehaviour
{
    public GameObject CharPanel;
   
    void Start()
    {
        CharPanel.SetActive(false);
    }

    public void CharUIOnOff()
    {
        bool panel = CharPanel.activeSelf;
        CharPanel.SetActive(!panel);
    }
}
