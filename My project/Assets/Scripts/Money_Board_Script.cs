using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money_Board_Script : MonoBehaviour
{
    public TextMeshProUGUI Total_Money;
    public GameObject On_Click;
    public GameObject Auto_Object1;
    int Click_Money;
    int Auto1_Money;

    int All_Money;
    // Start is called before the first frame update
    void Start()
    {

        Total_Money.text = "Current Money : " + Click_Money;
    }

    // Update is called once per frame
    void Update()
    {
        Add_Money();
        Total_Money.text = "Current Money : " + All_Money;
    }

    void Add_Money()
    {
        Click_Money = On_Click.GetComponent<On_Click_Script>().iMoney;
        Auto1_Money = Auto_Object1.GetComponent<Auto_Object_1>().Auto1_iMoney;

        All_Money = Click_Money + Auto1_Money;
    }
}
