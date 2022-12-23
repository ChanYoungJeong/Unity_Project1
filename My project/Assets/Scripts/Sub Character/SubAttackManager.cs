using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    PlayerScript playerStat;
    public Monster_Script monster;
    GameObject subStat;
    public GameObject fireBallAfter;

    float subDmg;

    Monster_Combat monsterCombat;

    // Start is called before the first frame update
    private void Start()
    {
        if (this.name == "dager(Clone)")
        {
            subStat = GameObject.Find("Rogue");
        }
        else if (this.name == "FireBall(Clone)")
        {
            subStat = GameObject.Find("MagicCaster");
        }
        else if (this.name == "Heal(Clone)")
        {
            subStat = GameObject.Find("Priest");
        }
        else if(this.name == "arrow(Clone)")
        {
            subStat = GameObject.Find("Archer");
        }
        else if (this.name == "bottle(Clone)")
        {
            subStat = GameObject.Find("Alchemist");
        }
        else if (this.name == "IceFang(Clone)")
        {
            subStat = GameObject.Find("IceMagican");
        }

        subDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;

    }

    public void Update()
    {
        if (Battle_Situation_Trigger.monster_group == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == Battle_Situation_Trigger.monster)
        {
            subDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;
            monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();


            monster = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            monster.nowHp -= subDmg;

            if(this.name == "FireBall(Clone)")
            {
                GameObject fire = Instantiate(fireBallAfter, monster.transform);
                monsterCombat.ApplyDamage(subDmg, Color.white);

                Destroy(fire, 0.45f);
            }
            else if(this.name == "dager(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.green);
            }
            else if(this.name == "arrow(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.black);
            }
            else if (this.name == "bottle(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.red);
            }
            else if (this.name == "IceFang(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.blue);
            }
            Destroy(this.gameObject);

        }
        else if (collision.name == "Heal(Clone)")
        {
            subDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;
            playerStat = GameObject.Find("Player").GetComponent<PlayerScript>();


            playerStat.nowHp += subDmg * 0.7f;

            if (playerStat.nowHp >= playerStat.maxHp)
            {
                playerStat.nowHp = playerStat.maxHp;  // 옵션 추가 가능하게 % 사용.
            }
            Destroy(SubBasicAttack.basicAttack, 0.5f);

        }
    }
}