using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dager : MonoBehaviour
{
    private SubCharacterStat subStat;
    Monster_Combat monsterCombat;


    private void Awake()
    {
        subStat = GameObject.Find("Rogue").GetComponent<SubCharacterStat>();
    }

    private void Update()
    {
        if (!SubCharManager.instans.CanAttack())
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponent<Monster_Script>() || collision.transform.GetComponent<BossMonster_Script>())
        {
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();

            monsterCombat.ApplyDamage(subStat.atkDamege, Color.green, 0, 0);
            Destroy(this.gameObject);
        }
    }
}
