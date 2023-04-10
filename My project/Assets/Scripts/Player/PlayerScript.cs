using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    public Transform TextPrinter;
    public GameObject PlayerText;
    public BossMonster_Script bossMonster; //
    private Monster_Script monster;

    Stat stat;

    private void Awake()
    {
        stat = GetComponent<Stat>();
    }
    public void GetExp()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
        }
         stat.player_nowExp += monster.Exp;

        if(stat.player_maxExp <= stat.player_nowExp)
        {
            LvUp();
            stat.player_nowExp -= stat.player_maxExp;
        }
    }
    public void LvUp()
    {
        stat.player_lv++;
        DisplayText(stat.player_lv + " Level UP", Color.yellow);
        SetStat();
        SetExp();
    }

    public void SetExp()
    {
        stat.player_maxExp = stat.player_maxExp + stat.player_lv * stat.player_lv* 5;
    }

    void SetStat()
    {
        float LvUp_Atk = 1f;
        float LvUp_Hp = 2f;
        float LvUp_CriticalRate = 0.1f;

        stat.player_atkDamage += (LvUp_Atk * stat.player_lv);
        stat.player_maxHp += (LvUp_Hp * stat.player_lv);
        stat.player_noxHp += (LvUp_Hp * stat.player_lv);
        stat.player_criticalRate += (LvUp_CriticalRate * stat.player_lv);
    }

    void DisplayText(string text, Color color)
    {
        GameObject hudText = Instantiate(PlayerText);
        hudText.transform.position = TextPrinter.position;
        hudText.GetComponent<PlayerText>()._Text = text;
        hudText.GetComponent<PlayerText>().textColor = color;
    }

}