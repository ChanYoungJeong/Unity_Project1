using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStat : MonoBehaviour
{
    public string monsterType;
    public float maxHp;
    public float nowHp;
    public int id;
    public string this_name;

    public BossStat(int _id, string _name, float _maxHP)
    {
        id = _id;
        this_name = _name;
        maxHp = _maxHP;
        nowHp = _maxHP;
    }
}