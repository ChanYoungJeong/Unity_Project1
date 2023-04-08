using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharPassive : MonoBehaviour
{
    public static GameObject RogueDark;

    SubChar_Combat_manager charSetting;
    //public GameObject[] skill;

    Animator Subanimator;

    public int changePassiveLv;

    private void Start()
    {
        charSetting = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>();
        Subanimator=charSetting.GetComponent<Animator>();
    }
    private void Update()
    {
        GeneratePassive();
    }

    public void GeneratePassive()
    {
        if (charSetting.lv >= 30)
        {
            GetPassive(1, charSetting.name);
            
        }
        if(charSetting.lv>= 50) 
        {
            GetPassive(2, charSetting.name);
        }
    }
    
    public void GetPassive(int index, string subCharName)
    {
        if (subCharName == "Rogue")
        {
            if (index == 1)
            {
                ChangePrefab1();
            }
            else if (index == 2)
            {
                ChangePrefab2();
            }
        }
    }
    public void ChangePrefab1()
    {
        GameObject rogueskill;
        rogueskill=charSetting.GetComponentInChildren<SubSkillAttack>().subSkillPrefab = Resources.Load<GameObject>("Ani/DarkCloud");
    }

    public void ChangePrefab2() 
    { 

    }

}
