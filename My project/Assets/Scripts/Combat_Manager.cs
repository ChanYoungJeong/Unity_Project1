using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Manager : MonoBehaviour
{
    PlayerScript Player_Status;
    Monster_Script Monster_Status;
    int Combat_Counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player_Status = transform.GetComponentInParent<PlayerScript>();
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
        StartCoroutine(Basic_Attack(Monster));
    }

    IEnumerator Basic_Attack(GameObject Monster)
    {
        Monster_Status = Monster.GetComponent<Monster_Script>();
        Monster_Status.nowHp -= Player_Status.atkDmg;
        yield return new WaitForSeconds(Player_Status.atkSpeed);
        Combat_Counter = 1;
        Debug.Log("Active?");
    }

}
