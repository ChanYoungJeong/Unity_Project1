using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public int id;
    public string Name;
    public float Damage;
    public float Duration;
    public float Cooldown;
    public int Number_of_Attack;
    public int Skill_Level;

    public Skills(int _id, string _Name, float _Damage, float _Duration, float _Cooldown, int _Number_of_Attack, int _Skill_Level)
    {
        id = _id;
        Name = _Name;
        Damage = _Damage;
        Duration = _Duration;
        Cooldown = _Cooldown;
        Number_of_Attack = _Number_of_Attack;
        Skill_Level = _Skill_Level;
    }

}
