using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour
{
    PlayerScript playerStatus;
    public List<Skills> skillLists = new List<Skills>();


    public bool activeSkillStart = false;
    private void Awake()
    {
        playerStatus = transform.GetComponentInParent<PlayerScript>();
        Generate();
    }

    //Generate Skills
    void Generate()
    {
        Skills skill_0 = new Skills(0, "Double Slash", 2.0f, 0.25f, 27.0f, 2, 1);
        Skills skill_1 = new Skills(1, "Fire Slash", 0.5f, 0.15f, 24.0f, 7, 1);
        Skills skill_2 = new Skills(2, "fountain of blood", 0.3f, 0.2f, 24.0f, 10, 1);
        Skills skill_3 = new Skills(3, "Darkness", 3.0f, 1.0f, 30.0f, 1, 1);



        //Add Skills to the list
        skillLists.Add(skill_0);
        skillLists.Add(skill_1);
        skillLists.Add(skill_2);
        skillLists.Add(skill_3);
    }

    public IEnumerator ActiveSkill(Skills skill_, GameObject Monster)
    {
        Monster_Script monsterStatus = Monster.GetComponent<Monster_Script>();
        Debug.Log("Active " + skill_._name);
        skillLists.Remove(skill_);
        for (int i = 0; i < skill_.numberOfAttack; i++)
        {
            monsterStatus.nowHp -= (int)(playerStatus.atkDmg * skill_.damage);
            if (monsterStatus.nowHp <= 0)
            {
                monsterStatus.nowHp = 0;
                Destroy(Monster);
            }

            Debug.Log("Apply " + skill_._name + " Damage " + (int)(playerStatus.atkDmg * skill_.damage) + " Monster Hp : " + monsterStatus.nowHp);
            yield return new WaitForSeconds(skill_.duration);
        }
        StartCoroutine(StartTimer(skill_));

        activeSkillStart = false;
    }

    public IEnumerator StartTimer(Skills skill_)
    {
        Debug.Log(skill_._name + " Cool Down Starts ");
        yield return new WaitForSeconds(skill_.cooldown);

        skillLists.Add(skill_);

        Debug.Log(skill_._name + " Cool Down Done ");
    }

}
