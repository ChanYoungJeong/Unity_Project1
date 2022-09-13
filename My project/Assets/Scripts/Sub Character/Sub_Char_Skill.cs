using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_Skill
{
    public int id;
    public string _name;
    public float damage;
    public float duration;
    public float cooldown;
    public int SubskillLevel;

    public Sub_Char_Skill(int id, string name, float damage, float duration, float cooldown, int SubskillLevel)
    {
        this.id = id;
        _name = name;
        this.damage = damage;
        this.duration = duration;
        this.cooldown = cooldown;
        this.SubskillLevel = SubskillLevel;
    }
}
