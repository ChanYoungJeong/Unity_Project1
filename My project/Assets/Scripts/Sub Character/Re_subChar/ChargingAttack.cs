using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingAttack : MonoBehaviour
{
    public GameObject chargingPrefab;
    public GameObject projectile;
    public float speed;
    public float x;
    public float destroyTime;

    private float angle;


    Stat stat;

    private void Awake()
    {
        stat = GetComponentInParent<Stat>();
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !BossScript.boss) return;

        GetTargetPosition(transform);
    }

    void CreateCharging(GameObject chargingPrefab)
    {
        GameObject chargingClone = Instantiate(chargingPrefab, transform.position, Quaternion.identity);
        Debug.Log(chargingClone);
        chargingClone.transform.position += new Vector3(x, 0, 0);

        Destroy(chargingClone, destroyTime);

        Invoke("CreatePrefab", destroyTime);
    }

    public void CreatePrefab()
    {
        GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
        projectileClone.GetComponent<Rigidbody2D>().AddForce(projectileClone.transform.right * speed, ForceMode2D.Impulse);
        if (projectileClone.GetComponent<PrefabOnTrigger>())
            projectileClone.GetComponent<PrefabOnTrigger>().damage = stat.atkDamage;

        Destroy(projectileClone, 5f);
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
