using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueAttack : MonoBehaviour
{
    public float x;
    public float destroyTime;
    Stat stat;
    Transform target;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();
    }
    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !BossScript.boss) return;

        target = Battle_Situation_Trigger.monster ? Battle_Situation_Trigger.monster.transform : BossScript.boss.transform;
    }

    void TargetAttack(GameObject slash)
    {

        GameObject slashClone = Instantiate(slash, target.position, Quaternion.identity);

        slashClone.transform.position += new Vector3(x, 0, 0);

        Destroy(slashClone, destroyTime);
    }
}
