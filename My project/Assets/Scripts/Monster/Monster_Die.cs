using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    public GameObject MonsterDieAnimation;
    PlayerExpBar playerExp;
    Monster_Script monster_Script;
    public DropBead DropBead;



    private void Awake()
    {
        if (GameObject.FindWithTag("Player"))
        {
            GameObject Player = GameObject.FindWithTag("Player");
            playerExp = Player.GetComponent<PlayerExpBar>();
        }
        monster_Script = GetComponent<Monster_Script>();
    }

    private void Update()
    {
        if (monster_Script.nowHp <= 0)
        {
            if (DropBead)
                DropBead.dropBead();

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
}
