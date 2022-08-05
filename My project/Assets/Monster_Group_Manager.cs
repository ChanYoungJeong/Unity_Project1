using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Group_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Number_of_Monster;
    public bool check_coroutine = true;

    public Create_Monster Creater;

    void Awake()
    {
        Number_of_Monster = set_Number_of_Monster(Stage_Manager.Stage);  //Set Number of Monster
        Creater = GetComponent<Create_Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0 && !check_coroutine) //When there is no moster in group
        {
            StartCoroutine(Go_To_Next_State());         //go to next stage
        }
    }

    IEnumerator Go_To_Next_State()             
    {
        yield return new WaitForSeconds(2.0f);
        Number_of_Monster = set_Number_of_Monster(Stage_Manager.Stage + 1);
        Stage_Manager.Stage++;                  //Go to next stage
        Destroy(gameObject);                    //Destory object
    }

    int set_Number_of_Monster(int stage)
    {
        int number;

        if((stage % Stage_Manager.Boss_Stage) > 0)
        {
            number = 3;             //Set the number of Normal Monster
        }
        else
        {
            number = 1;             //Set the number of Boss Monster
        }

        return number;
    }
}
