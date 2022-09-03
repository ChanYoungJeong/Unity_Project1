using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChar_Combat_manager : MonoBehaviour
{
    CharStats charStat;
    Sub_CharStats subCharStatus;
    Monster_Script monsterStatus;

    bool isAttack = false;      //Basic Attack Trigger

    public float maxHealth;   // ÃÖ´ë Ã¼·Â
    public float curHealth;
    public float maxMP; //ÃÖ´ë ¸¶³ª
    public float curMP;
    public float attack;
    public string this_name;
    public float atkSpeed;

    float timer = 1f;
    float time;

    void Start()
    {
        subCharStatus = gameObject.GetComponentInParent<Sub_CharStats>();
        SetSubChar();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle && isAttack == false)
        {
            isAttack = true;
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // ¹Þ¾Æ¿À´Â ¹æ¹ý¸¸ Ã£À¸¸é µÊ
            StartCoroutine(Basic_Attack());
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
            maxMP = charStat.maxMP;
            curMP = charStat.curMP;
            attack = charStat.attack;
            this_name = charStat.this_name;
            atkSpeed = charStat.atkSpeed;

        }
    }

    IEnumerator Basic_Attack()
    {
        monsterStatus.nowHp -= attack;
        
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

}