using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharPassive : MonoBehaviour
{
    SubCharSetting charSetting;
    SubSkillAttack subCharattack;
    public GameObject[] skill;

    private void Start()
    {
        charSetting = GameObject.Find("SubCharSetting").GetComponent<SubCharSetting>();
    }
    private void Update()
    {
        GeneratePassive();
    }

    public void GeneratePassive()
    {
        if (charSetting.player_LEVEL >= 30)
        {
            GetPassive(1, this.gameObject.name);
            
        }
        if(charSetting.player_LEVEL>= 50) 
        {
            GetPassive(2, this.gameObject.name);
        }
    }
    
    public void GetPassive(int index, string subCharName)
    {
        if (subCharName == "Rogue")
        {
            if (index == 1)
            {
                ChangePrefab();
            }
            else if (index == 2)
            {

            }
        }
    }
    public void ChangePrefab()
    {
        //subCharattack.GetComponent<SubSkillAttack>().subSkillPrefab = Resources.Load<GameObject>("Ani/FountainOfBlood");
        if (skill[0].name == "FountainOfBlood")
        {

        }
    }
    IEnumerator RogueSkill() {

        yield return new WaitForSeconds(0.1f); 
     }
}
