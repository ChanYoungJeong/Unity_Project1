using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [Tooltip("사용할 에니메이터의 트리거 이름을 적으시오")]
    [SerializeField] private string animatorName;

    Animator animator;
    Stat stat;

    private float angle;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        stat = GetComponent<Stat>();
    }

    private void Update()
    {
        GetTargetPosition(transform);
    }

    public void CreatePrefab(GameObject prefab)
    {
        if (Battle_Situation_Trigger.monster || CreateBoss.Bss)
        {
            animator.SetTrigger(animatorName);

            GameObject PrefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, angle));
            PrefabClone.GetComponent<Rigidbody2D>().AddForce(PrefabClone.transform.right * speed, ForceMode2D.Impulse);

            PrefabClone.GetComponent<Stat>().prefab_AtkDamege = stat.sub_atkDamege;
        }
    }

    public void GetTargetPosition(Transform transObj)
    {

        if (Battle_Situation_Trigger.monster)
        {
            angle = Mathf.Atan2(Battle_Situation_Trigger.monster.transform.position.y - transObj.position.y,
                                      Battle_Situation_Trigger.monster.transform.position.x - transObj.position.x) * Mathf.Rad2Deg;
        }
        else if (CreateBoss.Bss)
        {
            angle = Mathf.Atan2(CreateBoss.Bss.transform.position.y - transObj.position.y,
                                      CreateBoss.Bss.transform.position.x - transObj.position.x) * Mathf.Rad2Deg;
        }
    }
}
