using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    PlayerScript playerStat;
    public Monster_Script monster;
    public BossMonster_Script bossMonster;

    GameObject subStat;
    public GameObject fireBallAfter;
    
    float subDmg;
    float subBossDmg;

    Monster_Combat monsterCombat;
    Boss_Combat_Manager bossMonsterCombat;


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
        if (Battle_Situation_Trigger.monster_group == null || Boss_Combat_Manager.startbtnonclick)
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
                monsterCombat.ApplyDamage(subDmg, Color.white, 0, 0);

                Destroy(fire, 0.45f);
            }
            else if(this.name == "dager(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.green, 0, 0);
            }
            else if(this.name == "arrow(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.black, 0, 0);
            }
            else if (this.name == "bottle(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.red, 0, 0);
            }
            else if (this.name == "IceFang(Clone)")
            {
                monsterCombat.ApplyDamage(subDmg, Color.blue, 0, 0);
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
        else if(collision.gameObject == gameObject.GetComponent<BossMonster_Script>())
        {
            subBossDmg = subStat.GetComponent<SubChar_Combat_manager>().attackDmg;
            bossMonsterCombat = GameObject.Find("AB").GetComponent<Boss_Combat_Manager>();
            bossMonster = GameObject.Find("AB").GetComponent<BossMonster_Script>();
            bossMonster.nowHp -= subBossDmg;

            if (this.name == "FireBall(Clone)")
            {
                GameObject fire = Instantiate(fireBallAfter, monster.transform);
                bossMonsterCombat.ApplyDamage(subDmg, Color.white, 0, 0);

                Destroy(fire, 0.45f);
            }
            else if (this.name == "dager(Clone)")
            {
                bossMonsterCombat.ApplyDamage(subDmg, Color.green, 0, 0);
            }
            else if (this.name == "arrow(Clone)")
            {
                bossMonsterCombat.ApplyDamage(subDmg, Color.black, 0, 0);
            }
            else if (this.name == "bottle(Clone)")
            {
                bossMonsterCombat.ApplyDamage(subDmg, Color.red, 0, 0);
            }
            else if (this.name == "IceFang(Clone)")
            {
                bossMonsterCombat.ApplyDamage(subDmg, Color.blue, 0, 0);
            }
            Destroy(this.gameObject);
        }
    }
}