using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_Skill
{
    public int id; // �ĺ���ȣ
    public string _name; //��ų �̸�
    public float damage; //���ݷ�
    public float healing; //����
    public float defense; // ���
    public float cooldown; //��Ÿ��
    public int SubSkillLevel; //��ų����

    public Sub_Char_Skill(int id, string name, float damage, float healing,float defense,  float cooldown, int SubSkillLevel)
    {
        this.id = id;
        _name = name;
        this.damage = damage;
        this.healing = healing;
        this.defense = defense;
        this.cooldown = cooldown;
        this.SubSkillLevel = SubSkillLevel;
    }
}
