using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    SkilList skilList;
    Monster_Script monster;
    Monster_Manager monsterManager;
    Skills skill;

    private float timer;

    private void Start()
    {
        skilList = gameObject.GetComponentInParent<SkilList>();
    }


    public void _SkillAttack()
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();

        timer += Time.deltaTime;

        bool isFind = skilList.skilList.ContainsKey(this.name);
        if (isFind)
        {
            skill = skilList.skilList[this.name];
            for (int i = 0; i < skill.numberOfAttack; i++)
            {
                if (monster.nowHp > 0)
                {
                    monster.nowHp -= skill.damage;
                    Debug.Log(monster.nowHp);
                }
                else
                {
                    monsterManager.Monster_Die();
                }
            }
        }
    }
}