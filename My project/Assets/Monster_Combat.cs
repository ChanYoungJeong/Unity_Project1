using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Combat : MonoBehaviour
{
    Monster_Script Monster_Stat;
    PlayerScript Player_Stat;
    GameObject Monster_Parent;

    bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        Player_Stat = GameObject.Find("Player").GetComponent<PlayerScript>();
        Monster_Stat = this.GetComponent<Monster_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            if (Player_Stat && !check)
            {
                check = true;
                StartCoroutine(Attack());
            }
        }
        else
        {
            StopCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Monster_Stat.atkSpeed);       
        Player_Stat.nowHp -= Monster_Stat.atkDmg;
        Debug.Log("Monster Attack, Player Hp = " + Player_Stat.nowHp);
    }
}
