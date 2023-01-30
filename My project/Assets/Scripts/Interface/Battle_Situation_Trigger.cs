using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Situation_Trigger : MonoBehaviour
{
    public static GameObject monster;
    public static GameObject monster_group;
    GameObject player;

    public static bool on_Battle = false;
    public static bool atSpot = false;
    public bool Battle;
    bool coroutineCheck = false;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Battle = on_Battle;
        if (GameObject.Find("Monster_Group(Clone)"))
        {
            monster_group = GameObject.Find("Monster_Group(Clone)");
            if (monster_group.transform.childCount != 0)
            {
                monster = monster_group.transform.GetChild(0).gameObject;
                //on_Battle = true;
                if (coroutineCheck== false)
                {
                    coroutineCheck = true;
                    //player.GetComponent<PlayerScript>().PlayerAttackMotion();
                }
            }
            else
            {
                //on_Battle = false;
                monster = null;
                //player.GetComponent<PlayerScript>().PlayerIdleMotion();
                coroutineCheck = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Monster")
        {
            on_Battle = true;
            atSpot = true;
            player.GetComponent<PlayerScript>().PlayerAttackMotion();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Monster")
        {
            on_Battle = false;
            atSpot = false;
            player.GetComponent<PlayerScript>().PlayerIdleMotion();
        }
    }

}
