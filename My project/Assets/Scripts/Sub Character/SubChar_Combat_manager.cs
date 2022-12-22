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
    public float maxMP; //최대 마나
    public float curMP;
    public float attackDmg;
    public float healing;
    public string this_name;
    public float atkSpeed;
    public int lv;



    public float skillDamage;
    public float skillhealing;
    public float skilldefense;
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
            maxMP = charStat.maxMP;
            curMP = charStat.maxMP;
            attackDmg = charStat.attack;
            this_name = charStat.this_name;
            atkSpeed = charStat.atkSpeed;
            lv = charStat.lv;
        }
    }

    public void SetSkillStat()
    {
        bool isFind = false;
        string key = "";

        if (this.name == "Rogue")
        {
            isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("Kunai");
            key = "Kunai";
        }
        else if (this.name == "MagicCaster")
        {
            isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("Lightning");
            key = "Lightning";
        }

        else if (this.this_name == "Priest")
        {
            isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("Shield");
            key = "Shield";
        }

        else if (this.this_name == "Archer")
        {
            isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("WindArrow");
            key = "WindArrow";
        }

        else if (this.this_name == "Alchemist")
        {
            isFind = subCharSkillList.Sub_Char_SkilList.ContainsKey("AcidCloud");
            key = "AcidCloud";
        }

        if (isFind)
        {
            subSkillStat = subCharSkillList.Sub_Char_SkilList[key];

            skillDamage = subSkillStat.damage;
            skilldefense = subSkillStat.defense;
            skillhealing = subSkillStat.healing;
            skillcooldown = subSkillStat.cooldown;
            skillLv = subSkillStat.SubSkillLevel;

        }
    }

}