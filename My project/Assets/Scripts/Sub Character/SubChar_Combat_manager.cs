using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChar_Combat_manager : MonoBehaviour
{
    CharStats charStat;
    Sub_CharStats subCharStatus;
    Monster_Script monsterStatus;
    


    public float maxHealth;   // 최대 체력
    public float curHealth;
    public float maxMP; //최대 마나
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

        time += Time.deltaTime;
        if(timer > time)
        {
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // 받아오는 방법만 찾으면 됨
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

    IEnumerator Basic_Attack(GameObject Monster)
    {

        monsterStatus.nowHp -= attack;
        
        if (monsterStatus.nowHp <= 0)
        {
            monsterStatus.nowHp = 0;
        }
        Debug.Log(monsterStatus.nowHp);
        yield return new WaitForSeconds(atkSpeed); //error
    }

    IEnumerator Attack_Duration()
    {
        yield return new WaitForSeconds(atkSpeed); //error
    }

}