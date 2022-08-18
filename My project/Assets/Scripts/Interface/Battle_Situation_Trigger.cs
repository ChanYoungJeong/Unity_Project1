using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Situation_Trigger : MonoBehaviour
{
    public static bool on_Battle = false;
    public static GameObject monster;
    public static GameObject monster_group;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            monster = collision.gameObject;
            monster_group = collision.gameObject.transform.parent.gameObject;
            Debug.Log(monster_group.transform.childCount);
            on_Battle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            on_Battle = false;
        }

        //Monster_Script monster_stat = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();
    }
}
