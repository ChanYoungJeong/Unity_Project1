using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    Monster_Script Monster_Stat;
    public int scale = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Monster_Stat = GetComponent<Monster_Script>();
    }

    private void Start()
    {
        if (Game_System.bossStage)
        {
            SetBossMonsterStatus(scale);
        }
        else
        {
            SetMonsterStatus(scale);
        }
    }
    public void SetMonsterStatus(int scale)
    {
        Monster_Stat.maxHp = Get_Monster_HP(scale);
        Monster_Stat.nowHp = Get_Monster_HP(scale);
        Monster_Stat.atkDmg = Get_Monster_ATK(scale);
        Monster_Stat.atkSpeed = 1;
        Monster_Stat.Golds = Get_Monster_Gold(scale);
        Monster_Stat.Exp = Get_Monster_Exp(scale);
    }

    public void SetBossMonsterStatus(int scale)
    {
        Monster_Stat.maxHp = (int)(Get_Monster_HP(scale) * 2.2);
        Monster_Stat.nowHp = (int)(Get_Monster_HP(scale) * 2.2);
        Monster_Stat.atkDmg = (int)(Get_Monster_ATK(scale) * 2.2);
        Monster_Stat.atkSpeed = 2;
        Monster_Stat.Golds = (int)(Get_Monster_Gold(scale) * 2.2);
        Monster_Stat.Exp = (int)(Get_Monster_Exp(scale) * 2.2);
    }

    public int Get_Monster_HP(int scale)
    {
        int HP = 100 * ((scale) + 1);
        return HP;
    }

    public int Get_Monster_ATK(int scale)
    {
        int ATK = 2 * ((scale) + 1);
        return ATK;
    }
    
    public int Get_Monster_Gold(int scale)
    {
        int Gold = 10 * ((scale) + 1);
        return Gold;
    }
    
    public int Get_Monster_Exp(int scale)
    {
        int Exp = 5 * ((scale) + 1);
        return Exp;
    }


}