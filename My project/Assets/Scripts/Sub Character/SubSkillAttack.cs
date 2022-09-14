using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillAttack : MonoBehaviour
{
    Sub_Char_Skill SubCharSkill;
    Sub_Char_SkillList SubCharSkillList;

    Monster_Script monsterScript;
    bool isCoolTime = true;

    private void Start()
    {
        SetSubSkill();

    }

    private void Update()
    {
        if (isCoolTime)
        {
            StartCoroutine(SkillAttack());
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
        isCoolTime = false;

        monsterScript.nowHp -= SubCharSkill.damage;

        Debug.Log(this.name + "가 " + SubCharSkill.damage + "만큼 공격함");
        yield return new WaitForSeconds(SubCharSkill.cooldown);
        isCoolTime = true;
    }


}
