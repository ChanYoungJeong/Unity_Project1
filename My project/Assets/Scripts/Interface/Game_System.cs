using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_System : MonoBehaviour
{

    public static int Gold;
    public int _Gold;   //To Visualize Gold Amount
    public Text displyGold;

    public static int Stage = 1;
    public static int Boss_Stage = 5;
    public Text Stage_Text;

    // Update is called once per frame
    void Update()
    {
        _Gold = Gold;
        displyGold.text = "Gold : " + _Gold;
        displyGold.text = Gold.ToString() + "G";
        Stage_Text.text = "Stage " + Stage;
    }
}


       


