using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static GameObject boss;

    Monster_Script monster_Script;
    Animator bossAnimator;

    bool isBossDie = false;

    private void Awake()
    {
        boss = this.gameObject;
        monster_Script = GetComponent<Monster_Script>();
        bossAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(monster_Script.nowHp <= 0 && !isBossDie)
        {
            Debug.Log("���� ����");
            bossAnimator.SetTrigger("Boss_Death");

            isBossDie = true;
        }
    }

}
