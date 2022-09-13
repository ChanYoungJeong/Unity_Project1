using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChar_Combat_manager : MonoBehaviour
{
    CharStats charStat;
    Sub_CharStats subCharStatus;
    Monster_Script monsterStatus;

    Sub_Char_SkillList SubCharSkillList;
    Sub_Char_Skill SubCharSkill;


    bool isCoolTime = true;
    bool isAttack = false;      //Basic Attack Trigger

    public float maxHealth;   // ÃÖ´ë Ã¼·Â
    public float curHealth;
    public float attackDmg;
    public float healing;
    public float defense;
    public string this_name;
    public float atkSpeed;


    void Start()
    {
        subCharStatus = gameObject.GetComponentInParent<Sub_CharStats>();
        SetSubChar();
        SetSubSkill();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle && isAttack == false)
        {
            isAttack = true;
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // ¹Þ¾Æ¿À´Â ¹æ¹ý¸¸ Ã£À¸¸é µÊ
            

            StartCoroutine(Basic_Attack());
            if (isCoolTime)
            {
                StartCoroutine(SkillAttack());
                StopCoroutine(SkillAttack());
            }
        }
    }
    public void SetSubSkill()
    {
        bool isFind = SubCharSkillList.Sub_Char_SkilList.ContainsKey(this.name);
        if (isFind)
        {
            SubCharSkill = SubCharSkillList.Sub_Char_SkilList[this.name];
        }
    }

    public void SetSubChar()
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

    IEnumerator Basic_Attack()
    {
        monsterStatus.nowHp -= attackDmg;
        
        if (monsterStatus.nowHp <= 0)
        {
            monsterStatus.nowHp = 0;
        }
        Debug.Log("Sub Attack : " + monsterStatus.nowHp);
        yield return new WaitForSeconds(atkSpeed); //error
        isAttack = false;
        StopCoroutine(Basic_Attack());
    }

    IEnumerator Attack_Duration()
    {
        yield return new WaitForSeconds(atkSpeed); //error
    }

    IEnumerator SkillAttack()
    {
        isCoolTime = false;

        monsterStatus.nowHp -= SubCharSkill.damage;

        Debug.Log(this.name + "가 " + SubCharSkill.damage + "만큼 공격함");
        yield return new WaitForSeconds(SubCharSkill.cooldown);
        isCoolTime = true;
    }
}