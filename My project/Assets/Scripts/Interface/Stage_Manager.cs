using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Manager : MonoBehaviour
{
    public static int Stage = 1;
    public static int Boss_Stage = 5;
    public Text Stage_Text;
    private void Start()
    {

    }
    private void Update()
    {
        Stage_Text.text = "Stage : " + Stage;
    }
    

}
