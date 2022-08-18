using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public int id;
    public string _name;
    public float damage;
    public float duration;
    public float cooldown;
    public int numberOfAttack;
    public int skillLevel;

    public Skills(int id, string name, float damage, float duration, float cooldown, int numberOfAttack, int skillLevel)
    {
        this.id = id;
        _name = name;
        this.damage = damage;
        this.duration = duration;
        this.cooldown = cooldown;
        this.numberOfAttack = numberOfAttack;
        this.skillLevel = skillLevel;
    }

}
