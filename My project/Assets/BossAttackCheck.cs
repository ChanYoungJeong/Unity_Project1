using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCheck : MonoBehaviour
{
    public Animator[] subHeroAnimator; // �����ϱ�

    private Animator bossAnimator;

    bool isDie = false;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
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
                for(int i = 0; i<subHeroAnimator.Length; i++)
                {
                    Debug.Log("����");
                    subHeroAnimator[i].SetTrigger("Die");
                }

                isDie = true;
            }
        }
    }
}
