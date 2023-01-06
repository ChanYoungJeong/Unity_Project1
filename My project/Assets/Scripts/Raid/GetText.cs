using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour
{
    Sub_CharStats CharStats;
    public Text ScriptTxt;
   
    void Start()
    {
        ScriptTxt.text = "LV : " + GameObject.Find("Text : LV").GetComponent<CharStats>().lv;
    }

   
    void Update()
    {
        ScriptTxt.text = "LV : " + GameObject.Find("Text : LV").GetComponent<CharStats>().lv;
    }
}
