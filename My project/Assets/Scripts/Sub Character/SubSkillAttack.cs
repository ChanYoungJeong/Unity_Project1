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
            Debug.Log("��ų�� ã�� ���߽��ϴ�");
        }
    }

    IEnumerator SkillAttack()
    {
        isCoolTime = false;

        monsterScript.nowHp -= SubCharSkill.damage;

        Debug.Log(this.name + "�� " + SubCharSkill.damage + "��ŭ ������");
        yield return new WaitForSeconds(SubCharSkill.cooldown);
        isCoolTime = true;
    }


}
