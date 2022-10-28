using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChatStat : MonoBehaviour
{
    public GameObject SubStatWindow;
    public GameObject SubSetting;
    
    void Start()
    {
        SubStatWindow.SetActive(false);
    }

    public void SetActivePanel()
    {
        SubSetting.SetActive(false);

        if (SubStatWindow.activeSelf == false)
        {
            SubStatWindow.SetActive(true);
            SubStatWindow.SetActive(true);
        }

    }

    public void SetCloseStatWindow()
    {
        SubStatWindow.SetActive(false);
    }

    public void SetGoBackSetting()
    {
        SubStatWindow.SetActive(false);
        SubSetting.SetActive(true);

    }
}
