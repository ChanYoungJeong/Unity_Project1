using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Returning : MonoBehaviour
{
    Battle_Situation_Trigger BST;
    public Create_Monster create_Monster;

    public void ReturnButton()
    {
        Debug.Log(Battle_Situation_Trigger.monster.name);
        Debug.Log(Battle_Situation_Trigger.monster);
        if (Battle_Situation_Trigger.monster_group != null)
        {
            int count = GameObject.Find("Monster_Group(Clone)").transform.childCount;
            Destroy(GameObject.Find("Monster_Group(Clone)").gameObject);
            create_Monster.monster1_count = 0;
            Game_System.Stage = 1;
        }
        else
        {
            Game_System.Stage = 1;
        }
    }
}
