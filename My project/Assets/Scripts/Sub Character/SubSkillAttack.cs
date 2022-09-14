using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillAttack : MonoBehaviour
{
    Sub_Char_Skill SubCharSkill;
    Sub_Char_SkillList SubCharSkillList;
   
    Monster_Script monsterScript;
    bool isCoolTime = true;

    public GameObject subSkillPrefab;
    GameObject gameObject;
    Rigidbody2D rid;

    private void Start()
    {
        Debug.Log("SubSkillAttack");

        SubCharSkillList = transform.parent.GetComponentInParent<Sub_Char_SkillList>();

        SetSubSkill();

        Debug.Log("SetSubSkill() ���� �Ϸ�");
    }

    private void Update()
    {
        if (isCoolTime)
        {
            //StartCoroutine(SkillAttack());
            StopCoroutine(SkillAttack());
        }
    }

    public void SetSubSkill()
    {
        bool isFind = SubCharSkillList.Sub_Char_SkilList.ContainsKey(this.name);
        if (isFind)
        {
            SubCharSkill = SubCharSkillList.Sub_Char_SkilList[this.name];
        }
        else
        {
            Debug.Log("��ų�� ã�� ���߽��ϴ�");
        }
    }

    IEnumerator SkillAttack()
    {
        Debug.Log("SkillAttack() �ڷ�ƾ ����");

        isCoolTime = false;

        Debug.Log("monsterScript.nowHp : " + monsterScript.nowHp);
        Debug.Log("SubCharSkill.damage : " + SubCharSkill.damage);

        Debug.Log("asdkjflasdfhlasdf");
        monsterScript.nowHp -= SubCharSkill.damage;

        //Debug.Log(this.name + "�� " + SubCharSkill.damage + "��ŭ ������");
        yield return new WaitForSeconds(SubCharSkill.cooldown);
        isCoolTime = true;
    }

    public void RogueKunai()
    {
        gameObject = Instantiate(subSkillPrefab,this.transform.position, Quaternion.identity);
        rid = gameObject.GetComponent<Rigidbody2D>();
        rid.velocity = transform.forward * 20;

    }
}
