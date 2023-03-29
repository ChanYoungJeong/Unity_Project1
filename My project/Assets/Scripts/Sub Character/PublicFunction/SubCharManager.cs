using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharManager : MonoBehaviour
{
    public static SubCharManager instans;

    public float angle;
    private void Awake()
    {
        instans = this;
    }


    public void GetTargetPosition(Transform transObj)
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            angle = Mathf.Atan2(Battle_Situation_Trigger.monster.transform.position.y - transObj.position.y,
                                      Battle_Situation_Trigger.monster.transform.position.x - transObj.position.x) * Mathf.Rad2Deg;
        }
        else if (CreateBoss.Bss != null)
        {

            angle = Mathf.Atan2(CreateBoss.Bss.transform.position.y - transObj.position.y,
                                      CreateBoss.Bss.transform.position.x - transObj.position.x) * Mathf.Rad2Deg;
        }
    }

    public bool CanAttack()
    {
        if (Battle_Situation_Trigger.monster != null || CreateBoss.Bss != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
