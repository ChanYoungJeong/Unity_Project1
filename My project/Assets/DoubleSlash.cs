using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlash : MonoBehaviour
{
    public GameObject doubleSlashPrefaps;

    float x;
    float y;

    int count;

    Skills skill_0;
    private void Start()
    {
        skill_0 = new Skills(0, "Double Slash", 2.0f, 0.25f, 27.0f, 2, 1);
    }


    public void SkillAtack()
    {
        count = 0;
        while(count < 2)
        {
            if(doubleSlashPrefaps != null)
            {
                InvokeRepeating("CreatedSkill", 0f, skill_0.duration);
                count++;
            }
        }
    }

    public void CreatedSkill()
    {
        x = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<GameObject>().transform.position.x;
        x = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<GameObject>().transform.position.y;

        doubleSlashPrefaps = Instantiate(doubleSlashPrefaps, new Vector3(x, y, 0), Quaternion.identity);
        doubleSlashPrefaps.SetActive(true);
        Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>().nowHp -= (int)skill_0.damage;

        Debug.Log("몬스터 체력 : " + Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>().nowHp);
        Destroy(doubleSlashPrefaps, 0.1f);
    }
}
