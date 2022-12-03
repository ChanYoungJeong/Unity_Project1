using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuonoff : MonoBehaviour
{
    public GameObject MainOnOff;

    public void MainOnOffSetActive()
    {
        MainOnOff.SetActive(!MainOnOff.active);
    }
   
}
