using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_CharStats : MonoBehaviour
{
    public Dictionary<string, CharStats> SubChar = new Dictionary<string, CharStats>();

    void Awake()
    {
        Generate();
        //Sub_BaseStats(SubChar[gameObject.name]);
    }

    void Generate()
    {
        string name;

        name = "Sub 1";
        SubChar.Add(name, new CharStats(name, 100, 100, 10, 1));

        name = "Sub 2";
        SubChar.Add(name, new CharStats(name, 300, 100, 20, 2));


    }

    /*void Sub_BaseStats(CharStats Stat)
    {
        SC.maxHealth = Stat.maxHealth;
        SC.curHealth = Stat.curHealth;
        SC.maxMP = Stat.maxMP;
        SC.curMP = Stat.maxMP;
        SC.attack = Stat.attack;
        SC.this_name = Stat.this_name;
        SC.atkSpeed = Stat.atkSpeed;
    }*/
}