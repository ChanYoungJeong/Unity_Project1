using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [Header("���߰��� �ɼ�")]
    public bool multishot;
    public int numberOfProjectiles;

    [Header("���ϰ��� �ɼ�")]
    public bool singleshot;
    public int numberOfSingleProjectiles;

    [Header("����")]
    public string type;
    public int id;
    [Header("����")]
    public float maxHp;
    public float nowHp;
    public float atkDamage;
    public float criticalRate;
    public float atkSpeed;
    public int lv;
    [Header("��ų ����")]
    public float skillCooldown;
    public float skillDamage;
    [Header("���ο��� �� ���� ����")]
    public float maxExp;
    public float nowExp;
    public float shield;

}