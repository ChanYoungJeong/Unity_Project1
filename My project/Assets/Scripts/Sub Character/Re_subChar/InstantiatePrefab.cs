using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private GameObject prefab;


    private Stat stat;
    private float angle;
    // private float lastSkillAttackTime;

    private void Start()
    {
        stat = GetComponentInParent<Stat>();
    }


    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !BossScript.boss) return;

        GetTargetPosition(transform);
    }

    public void CreatePrefab(GameObject prefab)
    {
        if (stat.multishot)
        {

        }
        else
        {
            Create(prefab);
        }
    }

    void Create(GameObject prefab)
    {
        GameObject prefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle));
        prefabClone.GetComponent<Rigidbody2D>().AddForce(prefabClone.transform.right * speed, ForceMode2D.Impulse);
        if (prefabClone.GetComponent<PrefabOnTrigger>())
            prefabClone.GetComponent<PrefabOnTrigger>().damage = stat.atkDamage;

        Destroy(prefabClone, 5f);
    }


    public void GetTargetPosition(Transform transObj)
    {
        Transform target = TargetTrans();
        angle = Mathf.Atan2(target.position.y - transObj.position.y, target.position.x - transObj.position.x) * Mathf.Rad2Deg;
    }

    public Transform TargetTrans()
    {
        Transform transform = this.transform;
        if (Battle_Situation_Trigger.monster)
        {
            transform = Battle_Situation_Trigger.monster.transform;
        }
        else if (BossScript.boss)
        {
            transform = BossScript.boss.transform;
        }

        return transform;
    }
}