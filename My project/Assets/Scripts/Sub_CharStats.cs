using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_CharStats : MonoBehaviour
{
    Dictionary<string, CharStats> SubChar;
    CharStats SC;

    void Awake()
    {
        SC = GetComponentInChildren<CharStats>();
        Generate();
        Sub_BaseStats(SubChar[gameObject.name]);
    }


    void Generate()
    {
        SubChar = new Dictionary<string, CharStats>();
        CharStats SubChar_A = new CharStats("SubChar_A", 1000f, 50f, 10f);
        SubChar.Add("SubChar_A", SubChar_A);
    }

    void Sub_BaseStats(CharStats Stat)
    {
        SC.maxHealth = Stat.maxHealth;
        SC.curHealth = Stat.curHealth;
        SC.maxMP = Stat.maxMP;
        SC.curMP = Stat.maxMP;
        SC.attack = Stat.attack;
        SC.this_name = Stat.this_name;
    }
}