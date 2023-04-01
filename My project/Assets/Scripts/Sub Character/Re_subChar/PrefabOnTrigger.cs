using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnTrigger : MonoBehaviour
{
    Stat stat;
    Monster_Combat monsterCombat;
    Boss_Combat_Manager bossMonsterCombat;


    private void Awake()
    {
        stat = GetComponent<Stat>();
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Monster_Script>())
        {
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();
            monsterCombat.ApplyDamage(stat.prefab_AtkDamege, Color.green, 0, 0);

            Destroy(this.gameObject);
        }
    }
}
