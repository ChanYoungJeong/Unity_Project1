using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [Tooltip("기본공격이면 Type : Basic / 스킬이면 Type : Skill")]
    [SerializeField] private string Type;
    [SerializeField] private float speed = 20;
    [Tooltip("사용할 애니메이터 트리거 이름을 입력하세요.")]
    [SerializeField] private string animatorName;
    //[SerializeField] private string askillAnimatorName;
    [SerializeField] private GameObject prefab;
    //[SerializeField] private GameObject skillPrefab;
    [SerializeField] private float delayAnim;

    private Animator animator;
    private Stat stat;
    private float angle;
    private float lastAttackTime;
    // private float lastSkillAttackTime;
    public float prefabDamage;
    public float cooldown;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        stat = GetComponent<Stat>();
        lastAttackTime = Time.time;
        //cooldown값을 if문을 참조해서 받아올 것
        if(Type == "Basic")
        {
            cooldown = stat.sub_atkSpeed;
            prefabDamage = stat.sub_atkDamage;
        }
        else if(Type == "Skill")
        {
            cooldown = stat.sub_skillCooldown;
            prefabDamage = stat.sub_skillDamage;
        }
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster && !CreateBoss.Bss) return;

        GetTargetPosition(transform);

        if (Time.time > lastAttackTime + cooldown)
        {
            lastAttackTime = Time.time;
            animator.SetTrigger(animatorName);
            Invoke("CreatePrefabWithDelay", delayAnim);
        }
    }

    private void CreatePrefabWithDelay()
    {
        CreatePrefab(prefab, prefabDamage);
    }

    public void CreatePrefab(GameObject prefab, float damage)
    {

            GameObject prefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle));
            prefabClone.GetComponent<Rigidbody2D>().AddForce(prefabClone.transform.right * speed, ForceMode2D.Impulse);
        if (prefabClone.GetComponent<PrefabOnTrigger>())
            prefabClone.GetComponent<PrefabOnTrigger>().damage = damage;
    }

    public void GetTargetPosition(Transform transObj)
    {
        Transform target = Battle_Situation_Trigger.monster ? Battle_Situation_Trigger.monster.transform : CreateBoss.Bss.transform;
        angle = Mathf.Atan2(target.position.y - transObj.position.y, target.position.x - transObj.position.x) * Mathf.Rad2Deg;
    }
}