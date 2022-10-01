using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChar_Combat_manager : MonoBehaviour
{
    CharStats charStat;
    Sub_Char_Skill subSkillStat;
    Sub_CharStats subCharStatus;
    Sub_Char_SkillList subCharSkillList;


    bool isAttack = true;      //Basic Attack Trigger

    public float maxHealth;   
    public float curHealth;
    public float attackDmg;
    public float healing;
    public float defense;
    public string this_name;
    public float atkSpeed;

    public float skillDamage;
    public float skillLv;
    public float skillcooldown;



    void Start()
    {

        subCharStatus = transform.GetComponentInParent<Sub_CharStats>();
        subCharSkillList = transform.GetComponentInParent<Sub_Char_SkillList>();

        SetSubCharStat();
        SetSkillStat();
    }

    private void Update()
    {

    }
    

    public void SetSubCharStat()
    {
        bool isFind = subCharStatus.SubChar.ContainsKey(this.name);

        if (isFind)
        {
            charStat = subCharStatus.SubChar[this.name];

            maxHealth = charStat.maxHealth;
            curHealth = charStat.curHealth;
            attackDmg = charStat.attack;
            this_name = charStat.this_name;
            atkSpeed = charStat.atkSpeed;

        }
    }

    public  void SetSkillStat()
    {
        bool isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("Kunai");

        if (isFind)
        {
            subSkillStat = subCharSkillList.Sub_Char_SkilList["Kunai"];

            skillDamage = subSkillStat.damage;
            skillcooldown = subSkillStat.cooldown;
            skillLv = subSkillStat.SubSkillLevel;

        }
    }

}