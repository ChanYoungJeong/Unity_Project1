using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public float maxHealth;   // �ִ� ü��
    public float curHealth;
    public float maxMP; //�ִ� ����
    public float curMP;
    public float attack;
    public string this_name;
    public float atkSpeed;
    

    public CharStats(string _name, float _maxHealth, float _maxMP, float _attack, float _atkSpped)
    {
        this_name = _name;
        maxHealth = _maxHealth;
        curHealth = _maxHealth;
        maxMP = _maxMP;
        curMP = _maxMP;
        attack = _attack;
        atkSpeed = _atkSpped;
    }
}

