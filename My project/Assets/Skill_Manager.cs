using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour
{
    PlayerScript Player_Status;
    public List<Skills> Skill_Lists = new List<Skills>();

    public bool Active_Skill_Start = false;
    private void Awake()
    {
        Player_Status = transform.GetComponentInParent<PlayerScript>();
        Generate();
    }
    
    //Generate Skills
    void Generate()
    {
        Skills skill_0 = new Skills(0, "Double Slash", 0.7f, 0.25f, 3.0f, 2, 1);
        Skills skill_1 = new Skills(1, "Fire Slash", 0.5f, 0.1f, 5.0f, 7, 1);
        Skills skill_2 = new Skills(2, "fountain of blood", 0.3f, 0.2f, 4.0f, 5, 1);
        Skills skill_3 = new Skills(3, "Darkness", 3.0f, 1.0f, 10.0f, 1, 1);


        //Add Skills to the list
        Skill_Lists.Add(skill_0);
        Skill_Lists.Add(skill_1);
        Skill_Lists.Add(skill_2);
        Skill_Lists.Add(skill_3);
    }

    public IEnumerator Active_Skill(Skills skill_, GameObject Monster)
    {
        Monster_Script Monster_Status = Monster.GetComponent<Monster_Script>();
        Debug.Log("Active " + skill_.Name);
        Skill_Lists.Remove(skill_);
        for (int i = 0; i < skill_.Number_of_Attack; i++)
        {             
            Monster_Status.nowHp -= (int)(Player_Status.atkDmg * skill_.Damage);
            if(Monster_Status.nowHp <= 0)
            {
                Monster_Status.nowHp = 0;
                Destroy(Monster);
            }

            Debug.Log("Apply " + skill_.Name + " Damage "+ (int)(Player_Status.atkDmg * skill_.Damage) + " Monster Hp : " + Monster_Status.nowHp);
            yield return new WaitForSeconds(skill_.Duration);
        }
        //StartCoroutine(Start_Timer(skill_));
       
        Active_Skill_Start = false;
    }

    public IEnumerator Start_Timer(Skills skill_)
    {
        Debug.Log(skill_.Name + " Cool Down Starts ");
        yield return new WaitForSeconds(skill_.Cooldown);
        if(!Skill_Lists.Find(x => x.id == skill_.id))
        {
            Skill_Lists.Add(skill_);
        }
        Debug.Log(skill_.Name + " Cool Down Done ");
    }

}
