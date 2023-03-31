using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Group_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfMonster;
    public bool checkCoroutine = true;

    public Create_Monster CreaterMonster;



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
        Game_System.Stage++;                  //Go to next stage
    }

}
