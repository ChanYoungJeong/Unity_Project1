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
    public static GameObject MegaArrow;
    public static GameObject blizzardStorm;

    public Animator subAnimator;

    public List<GameObject> create;
    float angle;

    public Slider cooldownBar;

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



        if (this.name == "Kunai")
        {
            cooldownBar.value += Time.deltaTime * 1 / SubCharSkill.cooldown;
        }
        else if (this.name == "Lightning")
        {
            cooldownBar.value += Time.deltaTime * 1 / SubCharSkill.cooldown;

            if (Lightning != null && Battle_Situation_Trigger.monster != null)
            {
                Lightning.transform.position = new Vector2(Battle_Situation_Trigger.monster.transform.position.x,
                                                            Battle_Situation_Trigger.monster.transform.position.y + 1.4f);
            }
        }
        else if (this.name == "MegaArrow")
        {
            cooldownBar.value += Time.deltaTime * 1 / SubCharSkill.cooldown;

        }
        else if (this.name == "BlizzardStorm")
        {
            cooldownBar.value += Time.deltaTime * 1 / SubCharSkill.cooldown;

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

        angle = Mathf.Atan2(Battle_Situation_Trigger.monster.transform.position.y - this.transform.position.y,
                                               Battle_Situation_Trigger.monster.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;

        isCoolTime = false;
        if (this.name == "Kunai")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            RogueKunai();

        }
        else if (this.name == "Lightning")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            MagicCasterLightning();
        }
        else if (this.name == "MegaArrow")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            ArcherMegaArrow();
        }
        //else if(this.name == "신관 스킬"){}
        else if (this.name == "BlizzardStorm")
        {
            yield return new WaitForSeconds(SubCharSkill.cooldown);
            IceMagicanBlizzardStorm();
        }




        if (cooldownBar.value >= 1)
        {
            cooldownBar.value = 0;
        }

        isCoolTime = true;
    }

    public void RogueKunai()          // 도적 스킬
    {
        if (Battle_Situation_Trigger.monster != null)
        {


            subAnimator.SetTrigger("SkillNormal");
            kunai = Instantiate(subSkillPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
            kunai.GetComponent<Rigidbody2D>().AddForce(kunai.transform.right * 20, ForceMode2D.Impulse);
        }
    }
    public void MagicCasterLightning()        //마법사 스킬
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            subAnimator.SetTrigger("SkillMagic");
           
            LightningCreate();
            Invoke("LightningCreate", 0.4f);
            Invoke("LightningCreate", 0.8f);
        }
    }

    public void ArcherMegaArrow()           // 궁수 스킬
    {
        subAnimator.SetTrigger("SkillBow");
        Invoke("CreateMegaArrow", 0.7f);

    }

    public void CreateMegaArrow()
    {
        MegaArrow = Instantiate(subSkillPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
        MegaArrow.GetComponent<Rigidbody2D>().AddForce(MegaArrow.transform.right * 20, ForceMode2D.Impulse);
    }

    public void IceMagicanBlizzardStorm()       // 얼음 마법사 스킬
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            subAnimator.SetTrigger("SkillMagic");

            BlizzardStorm();
            Invoke("BlizzardStorm", 0.5f);
            Invoke("BlizzardStorm", 1.0f);
            Invoke("BlizzardStorm", 1.5f);
        }
    }

    public void BlizzardStorm()
    {
        for (int i = 0; i < create.Count; i++)
        {
            blizzardStorm = Instantiate(subSkillPrefab, create[i].transform.position, create[i].transform.rotation);
            blizzardStorm.GetComponent<Rigidbody2D>().AddForce(blizzardStorm.transform.forward * 8f, ForceMode2D.Impulse);
        }
    }


    public void LightningCreate()
    {
        monsterTrans = Battle_Situation_Trigger.monster.transform;
        Lightning = Instantiate(subSkillPrefab, new Vector3(monsterTrans.transform.position.x, monsterTrans.transform.position.y + 1.4f), Quaternion.identity);
    }

}