using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    Animator anim;
    //public GameObject MonsterDieAnimation;
    PlayerExpBar playerExp;
    Monster_Script monster_Script;
    public DropBead DropBead;
    Create_Monster createmonster;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (GameObject.FindWithTag("Player"))
        {
            GameObject Player = GameObject.FindWithTag("Player");
            playerExp = Player.GetComponentInParent<PlayerExpBar>();
        }
        monster_Script = GetComponentInParent<Monster_Script>();
        
    }

    private void Update()
    {
        if (monster_Script.nowHp <= 0)
        {
            if (DropBead)
                DropBead.dropBead();

            MonsterDieAnimation();

            playerExp.GetExp(monster_Script.Exp);
            Game_System.Gold += monster_Script.Golds;
        }
    }
    public void MonsterDieAnimation()
    {
        anim.SetTrigger("Death");
        //Instantiate(MonsterDieAnimation, this.transform.position, this.transform.rotation);
        //ShowPlayerStat();
        
    }
    public void MonsterDie()
    {
        Debug.Log(Battle_Situation_Trigger.monster);
        Destroy(Battle_Situation_Trigger.monster);
    }
}
