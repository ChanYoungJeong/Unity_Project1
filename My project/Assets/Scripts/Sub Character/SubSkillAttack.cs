using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSkillAttack : MonoBehaviour
{
    Sub_Char_Skill SubCharSkill;
    Sub_Char_SkillList SubCharSkillList;

    Transform monsterTrans;

    public bool isCoolTime = true;

    public GameObject subSkillPrefab;
    public static GameObject kunai;
    public static GameObject Lightning;

    public Animator subAnimator;


    //Slider cooldownBar;

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
        if(this.name == "Kunai")
        {
            //cooldownBar.value += Time.deltaTime * 1 / SubCharSkill.cooldown;
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

        if(this.name == "Kunai")
        {
            //cooldownBar = GameObject.Find("KunaiSlider").GetComponent<Slider>();
        }
    }

    IEnumerator SkillAttack()
    {
        isCoolTime = false;
        if (this.name == "Kunai")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            RogueKunai();
            /*if (cooldownBar.value >= 1)
            {
                cooldownBar.value = 0;
            }*/
        }

        else if (this.name == "Lightning")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            MagicCasterLightning();
        }
        //else if(this.name == "�Ű� ��ų"){}

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
    public void MagicCasterLightning()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            monsterTrans = Battle_Situation_Trigger.monster.transform;
            Lightning = Instantiate(subSkillPrefab, new Vector3(monsterTrans.transform.position.x, monsterTrans.transform.position.y + 1.4f), Quaternion.identity);
        }
    }

}