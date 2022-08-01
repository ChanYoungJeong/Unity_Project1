using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public float maxHealth;   // �ִ� ü��
    public float curHealth { get; private set; }
    public float maxMP; //�ִ� ����
    public float curMP { get; private set; }
    public float attack;

    public Stat damage;

private void Awake()
    {
        Debug.Log("hi");
    }
   
public void TakeDamage(int damage) // �ڽ��� ����ü�¿��� ������ ���ݷ� ����
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

