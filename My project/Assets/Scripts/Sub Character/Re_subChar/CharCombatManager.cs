using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombatManager : MonoBehaviour
{
    // Start is called before the first frame update

    Stat stat;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    float skillCollDown;
    [SerializeField]
    string BasicAttackAnimationName;
    [SerializeField]
    string SkillAttackAnimationName;

    private SubCoolTimeBar coolTimeBar;
    private Animator animator;
    bool canAttack;
    bool canSkill;

    void Awake()
    {
        stat = GetComponent<Stat>();
        animator = GetComponentInChildren<Animator>();
        
        coolTimeBar = GetComponent<SubCoolTimeBar>();
        canAttack = true;
        canSkill = false;
        attackSpeed = stat.atkSpeed;
        skillCollDown = stat.skillCooldown;

    }

    // Update is called once per frame
    void Update()
    {

        if (!Battle_Situation_Trigger.monster) return;

        if (GetComponent<SubCoolTimeBar>() && coolTimeBar.currentValue >= 1)
        {
            canSkill = true;
        }

        if (canAttack)
        {
            if (canSkill)
            {
                Skill();
                return;
            }
            else
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        //StopCoroutine(Attack());
        canAttack = false;
        animator.SetTrigger(BasicAttackAnimationName);

        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;

    }

    void Skill()
    {
        //StopCoroutine(Skill());
        canSkill = false;
        animator.SetTrigger(SkillAttackAnimationName);
        coolTimeBar.currentValue = 0;
    }
}
