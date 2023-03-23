using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_MeleeAttack : MonoBehaviour
{
    public Animator anim;
    SubChar_Combat_manager subStats;
    private Vector3 oriPosition; // 현재위치
    public float telePosition;
    public bool isCoolTime = true;

    public GameObject[] assassinWeapon;

    private void Start()
    {   //몬스터 위치 받아오기 -> 몬스터 뒤로 순간이동 -> 몬스터 몇초동안 공격 -> 원래 자리로 복귀(몬스터가 일찍 죽으면 바로 복귀)
        subStats = GetComponent<SubChar_Combat_manager>();
    }
    public void Update()
    {
        if (Battle_Situation_Trigger.monster != null || CreateBoss.Bss != null)
        {
            if (isCoolTime)
            {
                StartCoroutine(MeleeAttack());
            }
        }
    }
    public IEnumerator MeleeAttack()
    {
        isCoolTime = false;
        StopCoroutine(MeleeAttack());
        if (this.name == "Knife")
        {
            // Vector3 teleportPosition = 몬스터의 뒤로 이동 시키기;
            transform.position = ;
            yield return new WaitForSeconds(subStats.atkSpeed);

            transform.position = oriPosition;
            isCoolTime = true;
        }
    }
}