using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_MeleeAttack : MonoBehaviour
{
    public Animator anim;
    SubChar_Combat_manager subStats;
    private Vector3 oriPosition; // ������ġ
    public float telePosition;
    public bool isCoolTime = true;

    public GameObject[] assassinWeapon;

    private void Start()
    {   //���� ��ġ �޾ƿ��� -> ���� �ڷ� �����̵� -> ���� ���ʵ��� ���� -> ���� �ڸ��� ����(���Ͱ� ���� ������ �ٷ� ����)
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
            // Vector3 teleportPosition = ������ �ڷ� �̵� ��Ű��;
            transform.position = ;
            yield return new WaitForSeconds(subStats.atkSpeed);

            transform.position = oriPosition;
            isCoolTime = true;
        }
    }
}