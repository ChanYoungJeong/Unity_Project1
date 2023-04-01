using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Situation_Trigger : MonoBehaviour
{
    public static GameObject monster;
    public static GameObject monster_group;

    public static bool on_Battle = false;
    public CreateMonster_Manager CMM;


    private void Update()
    {
        if (CMM.group)
        {
            on_Battle = true;
            monster_group = CMM.group;
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
}
