using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    Monster_Script monsterStatus;

    public GameObject basicAttackPrefab;
    GameObject gameObject;
    Rigidbody2D rid;

    SubChar_Combat_manager rogueStat;

    bool isAttack = true;

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle && isAttack)
        {
            isAttack = false;
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // ����������?��? ������?���� ???����? ??

            //StartCoroutine(Attack());
            //StopCoroutine(Attack());
        }
    }
    public IEnumerator Attack()
    {
        RogueBasicAttack();
        yield return new WaitForSeconds(rogueStat.atkSpeed);
        isAttack = true;
    }

    public void RogueBasicAttack()
    {
        gameObject = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
        rid = gameObject.GetComponent<Rigidbody2D>();
        rid.velocity = transform.forward * 20;
        Debug.Log(rid.velocity);
       
        //���͸� ���� ����°� �����ϱ�

    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Monster")
        {
            monsterStatus.nowHp -= rogueStat.attackDmg;
            Debug.Log("���� ĳ���� ���� ��� : " + monsterStatus.nowHp);
            Destroy(gameObject);
        }
    }



}
