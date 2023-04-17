using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    public GameObject MonsterDieAnimation;
    Stat PlayerStat;
    PlayerExpBar playerExp;
    Monster_Script monster_Script;

    private void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerStat = Player.GetComponent<Stat>();
        playerExp = Player.GetComponent<PlayerExpBar>();
        monster_Script = GetComponent<Monster_Script>();
    }

    private void Update()
    {
        if (monster_Script.nowHp <= 0)
        {
            MonsterDie();
            playerExp.GetExp(monster_Script.Exp);
            Game_System.Gold += monster_Script.Golds;
        }
    }
    public void MonsterDie()
    {
        Instantiate(MonsterDieAnimation, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        //ShowPlayerStat();
    }

    void ShowPlayerStat()
    {
        Debug.Log("EXP: " + PlayerStat.nowExp);
        Debug.Log("Lv: " + PlayerStat.lv);
    }
}
