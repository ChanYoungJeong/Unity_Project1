using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    PlayerScript playerStat;
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
        else if(this.name == "Heal(Clone)")
        {
            subStat = GameObject.Find("Priest");
            playerStat = GameObject.Find("Player").GetComponent<PlayerScript>();
        }

        subDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;

    }

    public void Update()
    {
        if(Battle_Situation_Trigger.monster_group == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {       
        if (collision.gameObject == Battle_Situation_Trigger.monster)
        {
            if(this.name == "FireBall(Clone)")
            {
                Debug.Log("¥Í¿”");
            }
            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            monster.nowHp -= subDmg;
            Debug.Log("Sub character basic attack result : " + monster.nowHp);
            //Destroy(SubBasicAttack.basicAttack);
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            if (this.name == "Heal")
            {
                Debug.Log("healing");

                playerStat.nowHp += subDmg * 0.7f;
                if(playerStat.nowHp>=playerStat.maxHp)
                {
                    playerStat.nowHp = playerStat.maxHp;
                }
                Destroy(SubBasicAttack.basicAttack);
            }       
        }
    }

}
