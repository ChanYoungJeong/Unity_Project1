using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private GameObject prefab;


    private Stat stat;
    private float[] angle;
    // private float lastSkillAttackTime;

    private int max;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();

        max = (stat.numberOfProjectiles == 0) ? 1 : stat.numberOfProjectiles;
        angle = new float[max];

    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !BossScript.boss) return;

        GetTargetPosition(transform);
    }

    public void CreatePrefab(GameObject prefab)
    {
        for (int i = 0; i < max; i++)
        {
            GameObject prefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle[i])) as GameObject;
            prefabClone.GetComponent<Rigidbody2D>().AddForce(prefabClone.transform.right * speed, ForceMode2D.Impulse);
            if (prefabClone.GetComponent<PrefabOnTrigger>())
                prefabClone.GetComponent<PrefabOnTrigger>().damage = stat.atkDamage;


            Destroy(prefabClone, 5f);
        }
    }


    public void GetTargetPosition(Transform transObj)
    {
        Transform[] target;
        target = new Transform[max];
        Debug.Log(target[0]);
        target = TargetTrans();
        Debug.Log(target[0]);

        angle[0] = Mathf.Atan2(target[0].position.y - transObj.position.y, target[0].position.x - transObj.position.x) * Mathf.Rad2Deg;

        if (max != 1)
        {
            for (int i = 0; i < max; i++)
            {
                angle[i] = Mathf.Atan2(target[i].position.y - transObj.position.y, target[i].position.x - transObj.position.x) * Mathf.Rad2Deg;
            }
        }
    }

    public Transform[] TargetTrans()
    {
        Debug.Log("여기?");
        Transform[] transform;
        transform = new Transform[max];
        Debug.Log("여기는?");

        int monsterCount = Battle_Situation_Trigger.monster ?
            Battle_Situation_Trigger.monster_group.transform.childCount : 1;

        Debug.Log(monsterCount);

        if (Battle_Situation_Trigger.monster)
        {
            if (max == 1)
            {
                transform[0] = Battle_Situation_Trigger.monster ? 
                    Battle_Situation_Trigger.monster_group.transform.GetChild(0).gameObject.transform : BossScript.boss.transform;
                Debug.Log(transform[0]);
            }
            else
            {
                for (int i = 0; i < max; i++)
                {
                    transform[i] =
                        Battle_Situation_Trigger.monster_group.transform.GetChild(Random.Range(0, monsterCount - 1)).gameObject.transform;
                }
            }
        }
        else
        {
            transform[0] = BossScript.boss.transform;
        }

        Debug.Log(transform[0]);
        return transform;
    }
}