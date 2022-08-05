using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public float maxHealth;   // 최대 체력
    public float curHealth;
    public float maxMP; //최대 마나
    public float curMP;
    public float attack;
    public string this_name;
    

    public CharStats(string _name, float _maxHealth, float _maxMP, float _attack)
    {
        this_name = _name;
        maxHealth = _maxHealth;
        curHealth = _maxHealth;
        maxMP = _maxMP;
        curMP = _maxMP;
        attack = _attack;
    }
}

