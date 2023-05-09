using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainSubCharacterData : MonoBehaviour
{
    public Stat[] Char;



    [Header("다중공격 옵션")]
    public bool[] multishot;
    public int[] numberOfProjectiles;

    [Header("단일공격 옵션")]
    public bool[] singleshot;
    public int[] numberOfSingleProjectiles;

    [Header("종족")]
    public string[] type;
    public int[] id;
    [Header("스탯")]
    public float[] maxHp;
    public float[] nowHp;
    public float[] atkDamage;
    public float[] criticalRate;
    public float[] atkSpeed;
    public int[] lv;
    [Header("스킬 스탯")]
    public float[] skillCooldown;
    public float[] skillDamage;
    [Header("메인영웅 만 쓰는 스탯")]
    public float[] maxExp;
    public float[] nowExp;
    public float[] shield;

    private float time;
    private float maxtime = 1;

    private void Awake()
    {
        multishot = new bool[Char.Length];
        numberOfProjectiles = new int[Char.Length];
        singleshot = new bool[Char.Length];
        numberOfSingleProjectiles = new int[Char.Length];
        type = new string[Char.Length];
        id = new int[Char.Length];
        maxHp = new float[Char.Length];
        nowHp = new float[Char.Length];
        atkDamage = new float[Char.Length];
        criticalRate = new float[Char.Length];
        atkSpeed = new float[Char.Length];
        lv = new int[Char.Length];
        skillCooldown = new float[Char.Length];
        skillDamage = new float[Char.Length];
        maxExp = new float[Char.Length];
        nowExp = new float[Char.Length];
        shield = new float[Char.Length];

        for (int i = 0; i < Char.Length; i++)
        {
            id[i] = Char[i].id;
        }
    }

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (maxtime <= time)
        {
            time = 0;
            UpdateSubCharaterStatData();
        }
    }

    void UpdateSubCharaterStatData()
    {
        for (int i = 0; i < Char.Length; i++)
        {
            for (int j = 0; j < Char.Length; j++)
            {
                if (id[i] == Char[j].id)
                {
                    //다중공격옵션
                    multishot[i] = Char[j].multishot;
                    numberOfProjectiles[i] = Char[j].numberOfProjectiles;
                    //단일공격옵션
                    singleshot[i] = Char[j].singleshot;
                    numberOfSingleProjectiles[i] = Char[j].numberOfSingleProjectiles;
                    //종족
                    type[i] = Char[j].type;
                    //스탯
                    maxHp[i] = Char[j].maxHp;
                    nowHp[i] = Char[j].nowHp;
                    atkDamage[i] = Char[j].atkDamage;
                    criticalRate[i] = Char[j].criticalRate;
                    atkSpeed[i] = Char[j].atkSpeed;
                    //스킬 스탯
                    skillCooldown[i] = Char[j].skillCooldown;
                    skillDamage[i] = Char[j].skillDamage;
                    //메인스탯
                    maxExp[i] = Char[j].maxExp;
                    nowExp[i] = Char[j].nowExp;
                    shield[i] = Char[j].shield;
                }
            }
        }
    }

}
