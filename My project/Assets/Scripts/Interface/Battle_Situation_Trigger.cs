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
    bool coroutineCheck = false;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (GameObject.Find("Monster_Group(Clone)"))
        {
            on_Battle = true;
            monster_group = GameObject.Find("Monster_Group(Clone)");
            if (monster_group.transform.childCount != 0)
            {
                monster = monster_group.transform.GetChild(0).gameObject;
            }
            else
            {
                monster = null;
            }
        }
        else
        {
            on_Battle = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Monster")
        {
            collision.GetComponent<Stop_Monster>().atSpot = true;
        }
    }


}
