using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillAttack : MonoBehaviour
{
    Sub_Char_Skill SubCharSkill;
    Sub_Char_SkillList SubCharSkillList;
   
    bool isCoolTime = true;

    public GameObject subSkillPrefab;
    public static GameObject kunai;

    private void Start()
    {

        SubCharSkillList = transform.parent.GetComponentInParent<Sub_Char_SkillList>();

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
        yield return new WaitForSeconds(SubCharSkill.cooldown);
        RogueKunai();
        isCoolTime = true;
    }

    public void RogueKunai()
    {
        kunai = Instantiate(subSkillPrefab,this.transform.position, Quaternion.identity);
        kunai.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20, ForceMode2D.Impulse);

    }
}
