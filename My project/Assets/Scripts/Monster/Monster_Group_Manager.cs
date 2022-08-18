using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Group_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfMonster;
    public bool checkCoroutine = true;

    public Create_Monster CreaterMonster;

    void Awake()
    {
        numberOfMonster = SetNumberOfMonster(Stage_Manager.Stage);  //Set Number of Monster
        CreaterMonster = GetComponent<Create_Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0 && !checkCoroutine) //When there is no moster in group
        {
            StartCoroutine(GoToNextState());         //go to next stage
        }
    }

    IEnumerator GoToNextState()             
    {
        yield return new WaitForSeconds(2.0f);
        numberOfMonster = SetNumberOfMonster(Stage_Manager.Stage + 1);
        Stage_Manager.Stage++;                  //Go to next stage
        Destroy(gameObject);                    //Destory object
    }

    int SetNumberOfMonster(int stage)
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
