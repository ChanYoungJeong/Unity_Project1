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
        //Äí³ªÀÌ¸¦ ¸Ó ½ã´õº¼Æ®·Î ¹Ù²Û´Ù.
        GameObject rogueskill;
        rogueskill=charSetting.GetComponentInChildren<SubSkillAttack>().subSkillPrefab = Resources.Load<GameObject>("Ani/DarkCloud");
        //rogueskill = Instantiate(rogueskill, this.transform.position, Quaternion.identity);
        //rogueskill.GetComponent<Rigidbody2D>().velocity = Vector2.right;
        


        /*if (skill[0].name == "DarkCloud")
        {
            StartCoroutine("RogueSkill");
            StopCoroutine("RogueSkill");
        }*/
    }

    public void ChangePrefab2() 
    { 

    }

    /*IEnumerator RogueSkill() {
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
    }*/
}
