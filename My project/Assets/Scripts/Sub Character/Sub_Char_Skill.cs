using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_Skill
{
    public int id; // 식별번호
    public string _name; //스킬 이름
    public float damage; //공격력
    public float healing; //힐량
    public float defense; // 방어
    public float cooldown; //쿨타임
    public int SubSkillLevel; //스킬레벨

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
