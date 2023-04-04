using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [Tooltip("사용할 애니메이터 트리거 이름을 입력하세요.")]
    [SerializeField] private string animatorName;
    [SerializeField] private string askillAnimatorName;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject skillPrefab;

    private Animator animator;
    private Stat stat;
    private float angle;
    private float lastAttackTime;
    private float lastSkillAttackTime;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        stat = GetComponent<Stat>();
        lastAttackTime = Time.time;
        lastSkillAttackTime = Time.time;
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !CreateBoss.Bss) return;

        GetTargetPosition(transform);

        if (Time.time > lastAttackTime + stat.sub_atkSpeed)
        {
            lastAttackTime = Time.time;
            CreatePrefab(prefab, stat.sub_atkDamage, animatorName);
        }

        if (Time.time > lastSkillAttackTime + stat.sub_skillCooldown)
        {
            lastSkillAttackTime = Time.time;
            CreatePrefab(skillPrefab, stat.sub_skillDamage, askillAnimatorName);
        }
    }

    public void CreatePrefab(GameObject prefab, float damage, string aimName)
    {
        animator.SetTrigger(aimName);

        GameObject prefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle));
        prefabClone.GetComponent<Rigidbody2D>().AddForce(prefabClone.transform.right * speed, ForceMode2D.Impulse);
        prefabClone.GetComponent<PrefabOnTrigger>().damage = damage;

    }

    public void GetTargetPosition(Transform transObj)
    {
        Transform target = Battle_Situation_Trigger.monster ? Battle_Situation_Trigger.monster.transform : CreateBoss.Bss.transform;
        angle = Mathf.Atan2(target.position.y - transObj.position.y, target.position.x - transObj.position.x) * Mathf.Rad2Deg;
    }
}