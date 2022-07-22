using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Manager : MonoBehaviour
{
    PlayerScript Player_Status;
    Monster_Script Monster_Status;
    Skill_Manager Skills;
    int Combat_Counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player_Status = transform.GetComponentInParent<PlayerScript>();
        Skills = transform.parent.GetComponentInChildren<Skill_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Battle_Situation_Trigger.on_Battle)
        {
            while (Combat_Counter != 0)
            {
                Combat_Counter = 0;
                
                Active_Attack(Battle_Situation_Trigger.monster);
            }
        }
    }

    private void Active_Attack(GameObject Monster)
    {
        if (Skills.Skill_Lists.Count != 0)
        {
            for (int i = 0; i < Skills.Skill_Lists.Count; i++)
            {
                Skills.StartCoroutine(Skills.Start_Timer(Skills.Skill_Lists[0]));
                Skills.StartCoroutine(Skills.Active_Skill(Skills.Skill_Lists[0], Monster));
            }
            Combat_Counter = 1;
        }
        else
        {
            StartCoroutine(Basic_Attack(Monster));
        }
    }

    IEnumerator Basic_Attack(GameObject Monster)
    {
        Monster_Status = Monster.GetComponent<Monster_Script>();
        Monster_Status.nowHp -= Player_Status.atkDmg;
        Debug.Log(Monster_Status.nowHp);
        yield return new WaitForSeconds(Player_Status.atkSpeed);
        Combat_Counter = 1;
        
    }

    IEnumerator Attack_Duration()
    {
        yield return new WaitForSeconds(Player_Status.atkSpeed);
    }

}
