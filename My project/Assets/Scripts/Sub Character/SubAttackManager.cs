using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackManager : MonoBehaviour
{
    public Monster_Script monster;
    GameObject rogueStat;

    float rogueDmg;

    public bool isDestroy = false;
    // Start is called before the first frame update
    private void Start()
    {
        rogueStat = GameObject.Find("Rogue");
        rogueDmg = rogueStat.GetComponent<SubChar_Combat_manager>().attackDmg;
        //sS
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
        if (collision.tag == "Monster")
        {
            monster.nowHp -= rogueDmg;
            Debug.Log("���� ĳ���� ���� ��� : " + monster.nowHp);
            Destroy(SubBasicAttack.dager);
        }
    }
}
