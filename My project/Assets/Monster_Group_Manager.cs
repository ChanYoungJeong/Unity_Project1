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
        Number_of_Monster = 3;  //Set Number of Monster
        Creater = GetComponent<Create_Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0 && !check_coroutine)
        {
            StartCoroutine(Go_To_Next_State());    
        }
    }

    IEnumerator Go_To_Next_State()
    {
        yield return new WaitForSeconds(2.0f);
        Number_of_Monster = 3;
        Stage_Manager.Stage++;
        Debug.Log("Here ?");
        Destroy(gameObject);
    }
}
