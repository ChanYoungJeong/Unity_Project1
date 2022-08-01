using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public float maxHealth;   // 최대 체력
    public float curHealth { get; private set; }
    public float maxMP; //최대 마나
    public float curMP { get; private set; }
    public float attack;

    public Stat damage;

private void Awake()
    {
        Debug.Log("hi");
    }
   
public void TakeDamage(int damage) // 자신의 현재체력에서 몬스터의 공격력 빼기
{
    curHealth -= damage;
}

    public CharStats(string _name, float _maxHealth, float _maxMP, float _attack)
    {
        this.name = _name;
        this.maxHealth = _maxHealth;
        this.maxMP = _maxMP;
        this.attack = _attack;
    }
}

