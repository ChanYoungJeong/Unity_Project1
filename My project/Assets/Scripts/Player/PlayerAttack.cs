using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Stat stat;
    Monster_Combat monsterCombat;

    public Color color;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();
    }



    void PlayerBasicAttack()
    {
        monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();
        monsterCombat.ApplyDamage(stat.atkDamage, color, stat.criticalRate, 1.2f);
    }
}
