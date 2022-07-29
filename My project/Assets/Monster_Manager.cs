using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    Monster_Script Monster_Stat;
    // Start is called before the first frame update
    void Awake()
    {
        Monster_Stat = GetComponent<Monster_Script>();
        SetMonsterStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster_Stat.nowHp <= 0)
        {
            Monster_Die();
        }
    }


    void Monster_Die()
    {
        Destroy(this.gameObject);
        Game_System.Gold += Monster_Stat.Golds;
    }

    public void SetMonsterStatus()
    {
        Monster_Stat.monsterType = Get_Monster_Type(Stage_Manager.Stage);
        Monster_Stat.maxHp = Get_Monster_HP(Stage_Manager.Stage);
        Monster_Stat.nowHp = Get_Monster_HP(Stage_Manager.Stage); ;
        Monster_Stat.atkDmg = Get_Monster_ATK(Stage_Manager.Stage); ;
        Monster_Stat.atkSpeed = 7;
        Monster_Stat.Golds = Get_Monster_Gold(Stage_Manager.Stage);
    }

    public string Get_Monster_Type(int Stage)
    {
        int Boss_Stage = Stage % 10;

        if (Boss_Stage == 0)
        {
            return "Boss";
        }
        else {
            return "Normal";
        } 
    }

    public int Get_Monster_HP(int Stage)
    {
        int HP = 100 * ((Stage / 10) + 1);
        return HP;
    }

    public int Get_Monster_ATK(int Stage)
    {
        int ATK = 2 * ((Stage / 10) + 1);
        return ATK;
    }
    
    public int Get_Monster_Gold(int Stage)
    {
        int Gold = 10 * ((Stage / 10) + 1);
        return Gold;
    }
    


}
