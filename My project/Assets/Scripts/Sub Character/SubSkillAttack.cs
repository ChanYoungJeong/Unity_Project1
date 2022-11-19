using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillAttack : MonoBehaviour
{
    Sub_Char_Skill SubCharSkill;
    Sub_Char_SkillList SubCharSkillList;
   
    public bool isCoolTime = true;

    public GameObject subSkillPrefab;
    public static GameObject kunai;

    public Animator subAnimator;

    private void Start()
    {
        SubCharSkillList = transform.parent.GetComponentInParent<Sub_Char_SkillList>();
        SetSubSkill();

    }

    private void Update()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            if (isCoolTime)
            {
                StartCoroutine(SkillAttack());
                StopCoroutine(SkillAttack());
            }
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
        if (this.name == "Kunai")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            RogueKunai();
        }
        //else if(this.name == "신관 스킬"){}

        isCoolTime = true;
    }

    public void RogueKunai()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            subAnimator.SetTrigger("SkillNormal");
            kunai = Instantiate(subSkillPrefab, this.transform.position, Quaternion.identity);
            kunai.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20, ForceMode2D.Impulse);
        }
    }


}
