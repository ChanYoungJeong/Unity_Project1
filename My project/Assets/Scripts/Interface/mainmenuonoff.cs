using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuonoff : MonoBehaviour
{
    public GameObject SettingPanel;

    public void SettingPanelSetActive()
    {
        if (SettingPanel.activeSelf == false)
        {
            SettingPanel.SetActive(true);
        }
        else
        {
            SettingPanel.SetActive(false);
        }
    }

}
