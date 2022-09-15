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

        Debug.Log("SetSubSkill() 실행 완료");
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
            Debug.Log("스킬을 찾지 못했습니다");
        }
    }

    IEnumerator SkillAttack()
    {
        Debug.Log("SkillAttack() 코루틴 실행");

        isCoolTime = false;

        Debug.Log("monsterScript.nowHp : " + monsterScript.nowHp);
        Debug.Log("SubCharSkill.damage : " + SubCharSkill.damage);

        Debug.Log("asdkjflasdfhlasdf");
        monsterScript.nowHp -= SubCharSkill.damage;

        //Debug.Log(this.name + "가 " + SubCharSkill.damage + "만큼 공격함");
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
