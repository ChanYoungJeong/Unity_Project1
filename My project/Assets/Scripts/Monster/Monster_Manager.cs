using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    Monster_Script Monster_Stat;
    Animator anim;
    PlayerScript playerScript;

    bool check_animation = false;
    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        Monster_Stat = GetComponent<Monster_Script>();
        Get_Monster_Stat(Stage_Manager.Stage);
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("is_Dead", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster_Stat.nowHp <= 0 && check_animation == false)
        {
            StartCoroutine(Dead_Animation());
            Monster_Die();
        }
    }


    public void Monster_Die()
    {
        playerScript.GetExp();
        Destroy(this.gameObject);
        Game_System.Gold += Monster_Stat.Golds;
        ShowPlayerStat(); 
    }

    void SetMonsterStatus()
    {
        Monster_Stat.maxHp = Get_Monster_HP(Stage_Manager.Stage);
        Monster_Stat.nowHp = Get_Monster_HP(Stage_Manager.Stage);
        Monster_Stat.atkDmg = Get_Monster_ATK(Stage_Manager.Stage);
        Monster_Stat.atkSpeed = 7;
        Monster_Stat.Golds = Get_Monster_Gold(Stage_Manager.Stage);
        Monster_Stat.Exp = Get_Monster_Exp(Stage_Manager.Stage);
    }

    void SetBossMonsterStatus()
    {
        Monster_Stat.maxHp = (int)(Get_Monster_HP(Stage_Manager.Stage - 1) * 2.2);
        Monster_Stat.nowHp = (int)(Get_Monster_HP(Stage_Manager.Stage - 1) * 2.2);
        Monster_Stat.atkDmg = (int)(Get_Monster_ATK(Stage_Manager.Stage - 1) * 2.2);
        Monster_Stat.atkSpeed = 2;
        Monster_Stat.Golds = (int)(Get_Monster_Gold(Stage_Manager.Stage - 1) * 2.2);
        Monster_Stat.Exp = (int)(Get_Monster_Exp(Stage_Manager.Stage - 1) * 2.2);
    }

    void Get_Monster_Stat(int Stage)
    {
        int Boss_Stage = Stage % Stage_Manager.Boss_Stage;

        if (Boss_Stage > 0)
        {
            Monster_Stat.monsterType = "Normal";
            SetMonsterStatus();
        }
        else {
            Monster_Stat.monsterType = "Boss";
            SpriteRenderer color = GetComponent<SpriteRenderer>();
            color.color = Color.blue;
            SetBossMonsterStatus();
        } 
    }

    public int Get_Monster_HP(int Stage)
    {
        int HP = 100 * ((Stage / Stage_Manager.Boss_Stage) + 1);
        return HP;
    }

    public int Get_Monster_ATK(int Stage)
    {
        int ATK = 2 * ((Stage / Stage_Manager.Boss_Stage) + 1);
        return ATK;
    }
    
    public int Get_Monster_Gold(int Stage)
    {
        int Gold = 10 * ((Stage / Stage_Manager.Boss_Stage) + 1);
        return Gold;
    }
    
    public int Get_Monster_Exp(int Stage)
    {
        int Exp = 5 * ((Stage / Stage_Manager.Boss_Stage) + 1);
        return Exp;
    }

    IEnumerator Dead_Animation()
    {
        check_animation = true;
        anim.SetBool("is_Dead", true);
        yield return new WaitForSeconds(1.0f);
    }


    void ShowPlayerStat()
    {
        Debug.Log("EXP: "+playerScript.playerNowExp);
        Debug.Log("Lv: "+playerScript.lv);
    }
}