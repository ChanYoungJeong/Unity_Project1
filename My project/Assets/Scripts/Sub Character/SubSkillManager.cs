using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillManager : MonoBehaviour
{
    public Monster_Script monster;
    Monster_Combat monsterCombat;

    public GameObject rogue;
    float kunaiDmg;


    public bool isDestroy = false;
    // Start is called before the first frame update
    private void Start()
    {
        kunaiDmg = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>().skillDamage;
    }

    public void Update()
    {
        if (Battle_Situation_Trigger.monster == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();

        if (collision.gameObject == Battle_Situation_Trigger.monster)
        {
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();

            monster.nowHp -= kunaiDmg;

            if(this.name == "Kunai(Clone)")
            {
                monsterCombat.ApplyDamage(kunaiDmg, Color.yellow);

            }
            Destroy(SubSkillAttack.kunai);
        }
    }

}
