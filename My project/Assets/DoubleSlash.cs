using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlash : MonoBehaviour
{
    Monster_Script monster;
    SkilList skliiList;
    Monster_Manager monster_Manager;

    public void DoubleSlashAttack()
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
        int count = skliiList.skliiList.Find(doubleSlash => doubleSlash._name.Equals("Double Slash")).numberOfAttack;
        if (monster.nowHp > 0)
        {
            for(int i = 0; i < count; i++)
            {
                monster.nowHp = skliiList.skliiList.Find(doubleSlash => doubleSlash._name.Equals("doubleSlash")).damage;
                Debug.Log("doubleSlash Apply" + monster.nowHp);
                if (monster.nowHp <= 0) break;
            }
        }
        else
        {
            monster_Manager.Monster_Die();
        }

    }
}
