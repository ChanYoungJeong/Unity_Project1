using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    public Monster_Script monster;
    GameObject rogueStat;

    float rogueDmg;

    // Start is called before the first frame update
    private void Start()
    {
        if (this.name == "dager(Clone)")
        {
            rogueStat = GameObject.Find("Rogue");
            rogueDmg = rogueStat.GetComponent<SubChar_Combat_manager>().attackDmg;
        }
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
            
            if (this.name == "dager(Clone)")
            {
                monster.nowHp -= rogueDmg;
                Debug.Log("Sub character basic attack result : " + monster.nowHp);
                Destroy(SubBasicAttack.dager);
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        monster = null;

        if (collision.tag == "Monster")
        {

            if (this.name == "dager(Clone)")
            {
                Destroy(SubBasicAttack.dager);
            }
        }
    }
}
