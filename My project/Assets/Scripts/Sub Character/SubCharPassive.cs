using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharPassive : MonoBehaviour
{
    public GameObject subSkillPrefab;
    public static GameObject RogueDark;

    SubChar_Combat_manager charSetting;
    public GameObject[] skill;

    Animator Subanimator;

    private void Start()
    {
        charSetting = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>();
        Subanimator=charSetting.GetComponent<Animator>();
        Debug.Log(charSetting);
    }
    private void Update()
    {
        GeneratePassive();
    }

    public void GeneratePassive()
    {
        //Debug.Log(charSetting.name);
        //Debug.Log(charSetting.lv);
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
                ChangePrefab();
            }
            else if (index == 2)
            {

            }
        }
    }
    public void ChangePrefab()
    {
        Debug.Log(skill[0].name);
        //subCharattack.GetComponent<SubSkillAttack>().subSkillPrefab = Resources.Load<GameObject>("Ani/FountainOfBlood");
        if (skill[0].name == "DarkCloud")
        {
            StartCoroutine("RogueSkill");
            StopCoroutine("RogueSkill");
        }
    }
    IEnumerator RogueSkill() {
        yield return new WaitForSeconds(2f);
        RoguePassive();
     }

    public void RoguePassive()
    {
        if(Battle_Situation_Trigger.monster != null || CreateBoss.Bss != null)
        {
            Subanimator.SetTrigger("RoguePassive");
            Invoke("RogueCreateDark", 0.4f);
        }
    }
    public void RogueCreateDark()
    {
        RogueDark = Instantiate(skill[0], this.transform.position, Quaternion.identity);
        RogueDark.GetComponent<Rigidbody2D>().velocity = Vector2.right;

    }
}
