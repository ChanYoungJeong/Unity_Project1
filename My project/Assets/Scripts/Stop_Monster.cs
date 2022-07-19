using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Monster : MonoBehaviour
{
    private Rigidbody2D Rigid;
    public bool Monster_Stop = false;
    
    //Battle_Situation_Trigger

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.On_Battle)
        {
            Debug.Log(name);
            Rigid.velocity = Vector2.zero;
            Monster_Stop = true;
        }
        else
        {
            Monster_Stop = false;
        }
    }

}