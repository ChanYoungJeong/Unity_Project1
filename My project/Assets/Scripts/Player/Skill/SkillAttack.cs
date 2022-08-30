using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    SkilList skilList;
    Monster_Script monster;
    Monster_Manager monsterManager;
    Skills skill;
    public GameObject skillPrefab;

    private float timer;
    public bool isCoolTime = true;

    private void Start()
    {
        skilList = gameObject.GetComponentInParent<SkilList>();
    }

    public void _SkillAttack()
    {
        monster = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>();

        bool isFind = skilList.skilList.ContainsKey(this.name);

        if (isFind && isCoolTime)
        {
            skill = skilList.skilList[this.name];

            StartCoroutine(Skill());
            StopCoroutine(Skill());
        }
    }

    IEnumerator Skill()
    {

        for (int i = 0; i < skill.numberOfAttack; i++)
        {
            if (monster.nowHp > 0)
            {
                SkillMotion(i);
                monster.nowHp -= skill.damage;
                Debug.Log(monster.nowHp);
            }
            else
            {
                monsterManager.Monster_Die();
            }
        }
        isCoolTime = false;
        yield return new WaitForSeconds(skill.cooldown);
        isCoolTime = true;
    }

    public void SkillMotion(int i)
    {
        if(skillPrefab.name == "Double Slash")
        {
            GameObject doubleSlash = Instantiate(skillPrefab, monster.transform.position, Quaternion.identity);

            doubleSlash.SetActive(true);

            Debug.Log(doubleSlash.transform.GetChild(0).name);

            doubleSlash.transform.GetChild(0).gameObject.SetActive(false);
            doubleSlash.transform.GetChild(1).gameObject.SetActive(false);

            Debug.Log("더블 슬랙쉬 모션 생성");
            if (i == 0)
            {
                doubleSlash.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                doubleSlash.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(doubleSlash, 0.2f);
            }
        }
    }
}