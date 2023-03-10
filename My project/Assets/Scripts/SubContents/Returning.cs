using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Returning : MonoBehaviour
{
    Battle_Situation_Trigger BST;
    Create_Monster create_Monster;

    public void ReturnButton()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            BST.Battle = false;
            int count = GameObject.Find("Monster_Group(Clone)").transform.childCount;

            //Destroy(Battle_Situation_Trigger.monster_group);
            //Destroy(GameObject.Find("Monster_Group(Clone)").transform.GetChild);
            for (int i = 0; i <= count; i++)
            {
                Destroy(GameObject.Find("Monster_Group(Clone)").transform.GetChild(i).gameObject);
            }

            Game_System.Stage = 1;
        }
    }
}
