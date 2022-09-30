using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    //PlayerScript PlayerHP;

    public Monster_Script monster;
    GameObject rogueStat;

    //GameObject priestStat;

    float monsterHp;
    float rogueDmg;

   // float priestHp;
    //float priestDmg;

    // Start is called before the first frame update
    private void Start()
    {
        rogueStat = GameObject.Find("Rogue");
        rogueDmg = rogueStat.GetComponent<SubChar_Combat_manager>().attackDmg;

       // priestStat = GameObject.Find("Priest");
       // priestDmg = priestStat.GetComponent<SubChar_Combat_manager>().attackDmg;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
        if (collision.tag == "Monster")
        {

            monster.nowHp -= rogueDmg;
            Debug.Log("서브 캐릭터 공격 결과 : " + monster.nowHp);
            Destroy(this);

           // PlayerHP.nowHp += priestDmg * 0.7f;
           // Debug.Log("힐링 결과 : " + PlayerHP.nowHp);

        }
    }
}
