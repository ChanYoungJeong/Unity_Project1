using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_CharStats : MonoBehaviour
{
    Dictionary<string, CharStats> SubChar = new Dictionary<string, CharStats>();
    CharStats SC;

    void Awake()
    {
        Generate();
        Sub_BaseStats(SubChar [gameObject.name]);
        Debug.Log("hi");
    }


    void Generate()
    {
        SubChar = new Dictionary<string, CharStats>();

        string name;

        name = "SubChar_A";
        SubChar.Add(name, new CharStats(name, 1000, 50, 10));
    }

    void Sub_BaseStats(CharStats Stat)
    {
        SC = GetComponent<CharStats>();
        SC.maxHealth = Stat.maxHealth;

        Debug.Log(Stat.maxHealth);
    }
}