using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCheck : MonoBehaviour
{
    public Animator bossAnimator;

    private Animator animator;

    bool isDie = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDie)
        {
            Die();
        }
    }

    void Die()
    {
        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("Boss_SkillNormal"))
        {
            if (bossAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                Debug.Log("Á×À½");
                animator.SetTrigger("Die");

                isDie = true;
            }
        }
    }
}
