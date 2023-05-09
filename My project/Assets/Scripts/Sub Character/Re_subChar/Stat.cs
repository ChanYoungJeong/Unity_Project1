using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [Header("다중공격 옵션")]
    public bool multishot;
    public int numberOfProjectiles;

    [Header("단일공격 옵션")]
    public bool singleshot;
    public int numberOfSingleProjectiles;

    [Header("종족")]
    public string type;
    public int id;
    [Header("스탯")]
    public float maxHp;
    public float nowHp;
    public float atkDamage;
    public float criticalRate;
    public float atkSpeed;
    public int lv;
    [Header("스킬 스탯")]
    public float skillCooldown;
    public float skillDamage;
    [Header("메인영웅 만 쓰는 스탯")]
    public float maxExp;
    public float nowExp;
    public float shield;

}