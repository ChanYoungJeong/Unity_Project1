using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligntning : MonoBehaviour
{
    Stat stat;
    Transform target;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster) return;

        target = Battle_Situation_Trigger.monster ? 
            Battle_Situation_Trigger.monster.transform : CreateBoss.Bss.transform;
    }

    public void CreateLigntning(GameObject prefab)
    {
        GameObject prefabClone = Instantiate(prefab, 
            new Vector3(target.position.x, target.position.y, target.position.z), Quaternion.identity);


    }
}
