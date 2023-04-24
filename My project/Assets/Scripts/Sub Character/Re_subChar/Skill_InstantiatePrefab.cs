using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private GameObject prefab;




    private Stat stat;
    private float angle;
    private float time;
    // private float lastSkillAttackTime;

    private void Start()
    {
        stat = GetComponentInParent<Stat>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (!Battle_Situation_Trigger.monster && !BossScript.boss) return;

        GetTargetPosition(transform);
    }

    public void CreateSkillPrefab(GameObject prefab)
    {
        GameObject prefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle));
        prefabClone.transform.eulerAngles = new Vector3(0, 0, angle);
        prefabClone.GetComponent<Rigidbody2D>().AddForce(prefabClone.transform.right * speed, ForceMode2D.Impulse);
        if (prefabClone.GetComponent<PrefabOnTrigger>())
            prefabClone.GetComponent<PrefabOnTrigger>().damage = stat.skillDamage;
    }

    public void GetTargetPosition(Transform transObj)
    {
        Transform target = Battle_Situation_Trigger.monster ? Battle_Situation_Trigger.monster.transform : BossScript.boss.transform;
        angle = Mathf.Atan2(target.position.y - transObj.position.y, target.position.x - transObj.position.x) * Mathf.Rad2Deg;
    }

}
