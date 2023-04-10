using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Stat stat;
    Monster_Combat monsterCombat;
    Animator playerAnimator;

    public Color color;

    private bool isAttack = false;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle && !isAttack)
        {
            isAttack = !isAttack;
            playerAnimator.SetTrigger("AttackNormal");
        }
        else if (!isAttack)
        {
            playerAnimator.SetTrigger("Idle");
        }
    }


    void PlayerBasicAttack()
    {
        monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();
        monsterCombat.ApplyDamage(stat.player_atkDamage, color, stat.player_criticalRate, 0);
    }
}
