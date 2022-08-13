using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage_Manager : MonoBehaviour
{
    public static int Stage = 1;
    public static int Boss_Stage = 5;
    TextMeshProUGUI Stage_Text;
    private void Start()
    {
        Stage_Text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        Stage_Text.text = "Stage : " + Stage;
    }
    

}
