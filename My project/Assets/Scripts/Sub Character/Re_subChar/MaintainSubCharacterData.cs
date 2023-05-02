using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainSubCharacterData : MonoBehaviour
{
    public Stat[] Char;


    public bool[] multishot;

    [Header("Á¾Á·")]
    public string[] type;
    public int[] id;
    [Header("½ºÅÈ")]
    public float[] maxHp;
    public float[] nowHp;
    public float[] atkDamage;
    public float[] criticalRate;
    public float[] atkSpeed;
    public int[] lv;
    [Header("½ºÅ³ ½ºÅÈ")]
    public float[] skillCooldown;
    public float[] skillDamage;
    [Header("¸ÞÀÎ¿µ¿õ ¸¸ ¾²´Â ½ºÅÈ")]
    public float[] maxExp;
    public float[] nowExp;
    public float[] shield;

    private float time;
    private float maxtime = 1;

    private void Awake()
    {
        multishot = new bool[Char.Length];
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

        if(maxtime <= time)
        {
            time = 0;
            UpdateSubCharaterStatData();
        }
    }

    void UpdateSubCharaterStatData()
    {
        for(int i = 0; i<Char.Length; i++)
        {
            for(int j = 0; j<Char.Length; j++)
            {
                if (id[i] == Char[i].id)
                {
                    multishot[i] = Char[i].multishot;
                    type[i] = Char[i].type;
                    maxHp[i] = Char[i].maxHp;
                    nowHp[i] = Char[i].nowHp;
                    atkDamage[i] = Char[i].atkDamage;
                    criticalRate[i] = Char[i].criticalRate;
                    atkSpeed[i] = Char[i].atkSpeed;
                    skillCooldown[i] = Char[i].skillCooldown;
                    skillDamage[i] = Char[i].skillDamage;
                    maxExp[i] = Char[i].maxExp;
                    nowExp[i] = Char[i].nowExp;
                    shield[i] = Char[i].shield;
                }
            }
        }
    }

}
