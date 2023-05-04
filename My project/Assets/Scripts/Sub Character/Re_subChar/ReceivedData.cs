using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedData : MonoBehaviour
{
    MaintainSubCharacterData data;

    public Stat[] Char;


    private void Awake()
    {
        data = GameObject.Find("CharDataManager").GetComponent<MaintainSubCharacterData>();
        SetRaidCharStat();
    }

    void SetRaidCharStat()
    {
        for (int i = 0; i < data.Char.Length; i++)
        {
            for (int j = 0; j < data.Char.Length; j++)
            {
                if (Char[i].id == data.Char[j].id)
                {
                    Char[i].multishot = data.Char[j].multishot;
                    Char[i].type = data.Char[j].type;
                    Char[i].maxHp = data.Char[j].maxHp;
                    Char[i].nowHp = data.Char[j].nowHp;
                    Char[i].atkDamage = data.Char[j].atkDamage;
                    Char[i].criticalRate = data.Char[j].criticalRate;
                    Char[i].atkSpeed = data.Char[j].atkSpeed;
                    Char[i].skillCooldown = data.Char[j].skillCooldown;
                    Char[i].skillDamage = data.Char[j].skillDamage;
                    Char[i].maxExp = data.Char[j].maxExp;
                    Char[i].nowExp = data.Char[j].nowExp;
                    Char[i].shield = data.Char[j].shield;
                }
            }
        }
    }
}
