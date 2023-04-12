using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    public Transform TextPrinter;
    public GameObject PlayerText;

    Stat stat;

    private void Awake()
    {
        stat = GetComponent<Stat>();
    }
    
    public void GetExp(float monsterExp)
    {
         stat.nowExp += monsterExp;
    }


    public void SetExp()
    {
        stat.maxExp = stat.maxExp + stat.lv * stat.lv* 5;
    }

    void SetStat()
    {
        float LvUp_Atk = 1f;
        float LvUp_Hp = 2f;
        float LvUp_CriticalRate = 0.1f;

        stat.atkDamage += (LvUp_Atk * stat.lv);
        stat.maxHp += (LvUp_Hp * stat.lv);
        stat.nowHp += (LvUp_Hp * stat.lv);
        stat.criticalRate += (LvUp_CriticalRate * stat.lv);
    }

 

}