using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dager : MonoBehaviour
{
    private RogueStat rogueStat;
    Monster_Combat monsterCombat;


    private void Awake()
    {
        rogueStat = GameObject.Find("Rogue").GetComponent<RogueStat>();
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
        if(collision.gameObject == Battle_Situation_Trigger.monster || collision.gameObject == CreateBoss.Bss)
        {
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();

            monsterCombat.ApplyDamage(rogueStat.atkDamage, Color.green, 0, 0);
            Destroy(this.gameObject);
        }
    }
}
