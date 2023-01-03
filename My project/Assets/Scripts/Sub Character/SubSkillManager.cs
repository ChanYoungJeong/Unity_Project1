using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillManager : MonoBehaviour
{
    public Monster_Script monster;
    Monster_Script golbalMonster;
    Monster_Combat monsterCombat;

    float kunaiDmg;
    float LightningDmg;
    float BlizzardStormDmg;
    float MegaArrowDmg;

    public bool isDestroy = false;
    // Start is called before the first frame update
    private void Start()
    {
        kunaiDmg = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>().skillDamage;
        LightningDmg = GameObject.Find("MagicCaster").GetComponent<SubChar_Combat_manager>().skillDamage;
        BlizzardStormDmg = GameObject.Find("IceMagican").GetComponent<SubChar_Combat_manager>().skillDamage;
        MegaArrowDmg = GameObject.Find("Archer").GetComponent<SubChar_Combat_manager>().skillDamage;

    }

    public void Update()
    {
        if (Battle_Situation_Trigger.monster == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();

        if (collision.gameObject == Battle_Situation_Trigger.monster_group)
        {
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();

            if (this.name == "Kunai(Clone)")
            {
                monster.nowHp -= kunaiDmg;
                monsterCombat.ApplyDamage(kunaiDmg, Color.yellow, 0, 0);
                Destroy(SubSkillAttack.kunai);
            }
            else if (this.name == "Ligntning(Clone)")
            {
                SubSkillAttack.Lightning.transform.position = new Vector3(monster.transform.position.x, monster.transform.position.y + 1.4f);

                monster.nowHp -= LightningDmg;

                monsterCombat.ApplyDamage(LightningDmg, Color.magenta, 0, 0);
                Destroy(SubSkillAttack.Lightning, 0.35f);
            }
            
        }

        if(collision.GetComponent<Monster_Script>())
        {
            Monster_Script _monster = collision.GetComponent<Monster_Script>();
            Monster_Combat _monsterCombat = collision.GetComponent<Monster_Combat>();
            if (this.name == "Snow(Clone)")
            {
                _monster.nowHp -= BlizzardStormDmg;


                _monsterCombat.ApplyDamage(BlizzardStormDmg, Color.blue, 0, 0);
                Destroy(SubSkillAttack.blizzardStorm);
            }

            if (this.name == "MegaArrow(Clone)")
            {
                _monster.nowHp -= MegaArrowDmg;

                _monsterCombat.ApplyDamage(MegaArrowDmg, Color.blue, 0, 0);
                Destroy(SubSkillAttack.MegaArrow, 3f);
            }
        }
    }

}