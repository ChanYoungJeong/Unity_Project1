using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnTrigger : MonoBehaviour
{
    Monster_Combat monsterCombat;
    public float damage;

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
            monsterCombat.ApplyDamage(damage, Color.green, 0, 0);

            Destroy(this.gameObject);
        }
    }
}
