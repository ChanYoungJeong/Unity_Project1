using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster_Manager : MonoBehaviour
{

    public Transform[] spawnArray;
    public GameObject monster_Group;
    public GameObject group;
    [SerializeField]
    int monsterCapacity = 9;
    [SerializeField]
    int bossMonsterCapacity = 3;
    [SerializeField]
    float stageDelay = 2.5f;
    [SerializeField]
    int stageScale = 0;
    void Update()
    {
        //If there are no group, create Monster Group
        if (group == null)
        {
            Game_System.Stage++;
            createMonsterGroup();
        }
    }

    void createMonsterGroup()
    {
        group = Instantiate(monster_Group, transform.position, transform.rotation);
        Create_Monster groupCM;
        groupCM = group.GetComponent<Create_Monster>();
        groupCM.spawnArray = spawnArray;
        groupCM.scale = SetStageStatScale();
        groupCM.monsterCapacity = SetNumberOfMonster(Game_System.Stage + 1);
    }

    int SetNumberOfMonster(int stage)
    {
        if (!Game_System.bossStage)
        {
            return monsterCapacity;         //Set the number of Normal Monster
        }
        else
        {
            return bossMonsterCapacity;     //Set the number of Boss Monster
        }
    }

    int SetStageStatScale()
    {
        if (Game_System.bossStage)
        {
            stageScale++;        
        }
        return stageScale;
    }
}
