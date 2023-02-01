using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    public Transform TextPrinter;
    public GameObject PlayerText;
    Monster_Script monster;
    Monster_Combat monsterCombat;

    public float maxHp;
    public float nowHp;
    public bool attacked;
    public float atkDmg;
    public float atkSpeed;

    public int lv;
    public int playerMaxExp;
    public int playerNowExp;
    public float criticalRate;
    public float criticalDamage;

    public Animator playerAnimator;
    public CharacterController characterController;
    public GameObject square;
    private void InputControlVector()
    {
        if (characterController)
        {
            //characterController.Move(inputDirection);
        }
    }

    private void Start()
    {
        SetStat();
        SetExp();

        square.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BasicAttackMotion();
        }
    }

    public void PlayerIdleMotion()
    {
        playerAnimator.SetTrigger("Idle");
        StopCoroutine(PlayerBasicAttack());
    }

    public void PlayerAttackMotion()
    {
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
        if(Battle_Situation_Trigger.monster != null)
        {
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();
            playerAnimator.SetTrigger("AttackNormal");
            monsterCombat.ApplyDamage(atkDmg, Color.red, criticalRate, criticalDamage);

            if (monster.nowHp <= 0)
            {
                monster.nowHp = 0;
                StopCoroutine(PlayerBasicAttack());
            }
            else
            {
            }
        }
    }
  
    public void GetExp()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
        }
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
        DisplayText(lv + " Level UP", Color.yellow);
        SetStat();
    }

    public void SetExp()
    {
        playerMaxExp = playerMaxExp + lv * lv * 5;
    }

    void SetStat()
    {
        float LvUp_Atk = 1f;
        float LvUp_Hp = 2f;
        float LvUp_CriticalRate = 0.1f;

        atkDmg += (LvUp_Atk * lv);
        maxHp += (LvUp_Hp * lv);
        nowHp += (LvUp_Hp * lv);
        criticalRate += (LvUp_CriticalRate * lv);
    }

    void DisplayText(string text, Color color)
    {
        GameObject hudText = Instantiate(PlayerText);
        hudText.transform.position = TextPrinter.position;
        hudText.GetComponent<PlayerText>()._Text = text;
        hudText.GetComponent<PlayerText>().textColor = color;
    }


    public void BasicAttackMotion()
    {
        square.SetActive(true);
        playerAnimator.SetTrigger("AttackNormal");
        Invoke("TrailSetActive", 0.5f);
    }

    void TrailSetActive()
    {
        square.SetActive(false);
    }
}