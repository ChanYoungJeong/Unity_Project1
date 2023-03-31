using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharacterStat : MonoBehaviour
{
    public float maxHp => _maxHp;
    public float nowHp => _maxHp;
    public float atkDamege => _atkDamage;
    public float criticalRate => _criticalRate;
    public float atkSpeed => _atkSpeed;
    public int lv => _lv;

    [SerializeField] private float _maxHp;
    [SerializeField] private float _atkDamage;
    [SerializeField] private float _criticalRate;
    [SerializeField] private float _atkSpeed;
    [SerializeField] private int _lv;
}
