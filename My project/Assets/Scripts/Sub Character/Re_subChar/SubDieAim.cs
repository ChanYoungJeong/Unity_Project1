using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDieAim : MonoBehaviour
{
    public Animator[] subAnimator;

    Animator bossAnimator;
    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
    }

    void DieAnimation()
    {
        if(bossAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            for (int i = 0; i < subAnimator.Length; i++){
                subAnimator[i].SetTrigger("Death");
            }
        }
    }
}
