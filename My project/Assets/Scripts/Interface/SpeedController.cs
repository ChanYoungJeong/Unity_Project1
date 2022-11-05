using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    public Text speedText;
    int SpeedCheck;

    private void Start()
    {
        SpeedCheck = 1;
    }

    public void ChangeSpeed()
    {

        if (SpeedCheck == 1)
        {
            SpeedCheck = 2;
            Time.timeScale = 2;
            speedText.text = "x2";
        }
        else
        {
           SpeedCheck = 1;
           Time.timeScale = 1;
           speedText.text = "x1";
        }
        
    }
}
