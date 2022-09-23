using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerIdleMotion;
    public GameObject playerAttackMotion;
    public Monster_Script monster;

    public float maxHp;
    public float nowHp;
    public bool attacked;
    public float atkDmg;
    public float atkSpeed;

    public int lv;
    public int playerMaxExp;
    public int playerNowExp;
    public int critical;

    private void Start()
    {
        
    }
    public void PlayerIdleMotion()
    {
        playerIdleMotion.SetActive(true);
        playerAttackMotion.SetActive(false);

        StopCoroutine(PlayerBasicAttack());
    }

    public void PlayerAttackMotion()
    {
        playerIdleMotion.SetActive(false);
        playerAttackMotion.SetActive(true);

        StartCoroutine(PlayerBasicAttack());
    }

    IEnumerator PlayerBasicAttack()
    {
        while (Battle_Situation_Trigger.on_Battle)
        {
            yield return new WaitForSeconds(atkSpeed);
        
            _PlayerAttack();
        }
    }

    public void _PlayerAttack()
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
        if( monster != null)
        {
            monster.nowHp -= atkDmg * critical;
            
            if (monster.nowHp <= 0)
            {
                monster.nowHp = 0;
                Debug.Log(monster.nowHp);
                StopCoroutine(PlayerBasicAttack());
            }
            else
            {
                Debug.Log(monster.nowHp);
            }
        }

    }

    

    public void GetExp()
    {
        playerNowExp += monster.Exp;

        if(playerMaxExp <= playerNowExp)
        {
            LvUp();
            playerNowExp -= playerMaxExp;

            SetExp();
        }
    }

    public void LvUp()
    {
        lv++;
        Debug.Log("Player LV : " + lv);
    }

    public void SetExp()
    {
        playerMaxExp = playerMaxExp + lv * lv * 5;
    }

}
