using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    public Monster_Script monster;
    GameObject subStat;

    float subDmg;

    // Start is called before the first frame update
    private void Start()
    {
        if (this.name == "dager(Clone)")
        {
            subStat = GameObject.Find("Rogue");
        }
        else if(this.name == "FireBall(Clone)")
        {
            subStat = GameObject.Find("MagicCaster");
        }

        subDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;

    }

    public void Update()
    {
        if(Battle_Situation_Trigger.monster == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
        if (collision.tag == "Monster")
        {
            if(this.name == "FireBall(Clone)")
            {
                Debug.Log("¥Í¿”");
            }


            monster.nowHp -= subDmg;
            Debug.Log("Sub character basic attack result : " + monster.nowHp);
            Destroy(SubBasicAttack.basicAttack);
            
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        monster = null;

        if (collision.tag == "Monster")
        {
             Destroy(SubBasicAttack.basicAttack);
        }
    }
}
