using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Monster : MonoBehaviour
{
    private Rigidbody2D rigid;
    public bool monster_Stop = false;
    public float speed = 3.0f;
    private Rigidbody2D monster1_Rigid;


    public PlayerScript playerScript;
    public Monster_Script monster_Script;

    //Battle_Situation_Trigger

    private void Awake()
    {
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (monster_Script != null)
        {
           monster_Script = Battle_Situation_Trigger.monster.GetComponent<Monster_Script>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            rigid.velocity = Vector2.zero;
            monster_Stop = true;

        }
        else
        {
            Move_Left();
            monster_Stop = false;
        }
    }

    private void Move_Left()
    {
        monster1_Rigid = GetComponent<Rigidbody2D>();
        monster1_Rigid.velocity = transform.right * -1 * speed;
    }
}