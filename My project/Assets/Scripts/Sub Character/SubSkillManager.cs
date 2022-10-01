using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillManager : MonoBehaviour
{
    public Monster_Script monster;

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
            Destroy(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();

        if (collision.tag == "Monster")
        {

            monster.nowHp -= kunaiDmg;
            Debug.Log("Sub character skill attack result : " + monster.nowHp);
            Destroy(SubSkillAttack.kunai);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        monster = null;

        if (collision.tag == "Monster")
        {
            Destroy(SubSkillAttack.kunai);
        }
    }
}
