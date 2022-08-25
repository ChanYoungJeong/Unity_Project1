using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Situation_Trigger : MonoBehaviour
{
    public static GameObject monster;
    public static GameObject monster_group;
    public GameObject player;

    public static bool on_Battle = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            monster = collision.gameObject;
            monster_group = collision.gameObject.transform.parent.gameObject;
            //Debug.Log(monster_group.transform.childCount);

            on_Battle = true;
            player.GetComponent<PlayerScript>().PlayerAttackMotion();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            player.GetComponent<PlayerScript>().PlayerIdleMotion();

            on_Battle = false;
        }
        //Monster_Script monster_stat = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
    }
}
