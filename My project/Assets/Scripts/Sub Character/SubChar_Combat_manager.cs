using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubChar_Combat_manager : MonoBehaviour
{
    CharStats charStat;
    Sub_CharStats subCharStatus;
    Monster_Script monsterStatus;

    public GameObject basicAttackPrefab;
    GameObject gameObject;
    Rigidbody2D rid;

    bool isAttack = true;      //Basic Attack Trigger

    public float maxHealth;   // ÃÖ´ë Ã¼·Â
    public float curHealth;
    public float attackDmg;
    public float healing;
    public float defense;
    string this_name;
    public float atkSpeed;


    void Start()
    {

        subCharStatus = transform.GetComponentInParent<Sub_CharStats>();
        SetSubChar();

    }

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle && isAttack == true)
        {
            isAttack = false;
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // ¹Þ¾Æ¿À´Â ¹æ¹ý¸¸ Ã£À¸¸é µÊ

           // StartCoroutine(Basic_Attack());
            
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
        if(this.name == "Rouge")
        {
            RogueBasicAttack();
        }
        monsterStatus.nowHp -= attackDmg;

        Debug.Log(monsterStatus.nowHp);
        
        
        if (monsterStatus.nowHp <= 0)
        {
            monsterStatus.nowHp = 0;
        }
        yield return new WaitForSeconds(atkSpeed); //error
        isAttack = true;
        StopCoroutine(Basic_Attack());
    }

    public void RogueBasicAttack()
    {
        gameObject = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
        rid = gameObject.GetComponent<Rigidbody2D>();
        rid.velocity = transform.forward * 20;
        //몬스터를 향해 날라는거 구현하기

    }

    
}