using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Monster : MonoBehaviour
{
    private Rigidbody2D rigid;
    public bool monster_Stop = false;
    public float speed = 3.0f;
    public bool atSpot = false;

    public PlayerScript playerScript;
    public Monster_Script monster_Script;


    bool isDie = false;
    //Battle_Situation_Trigger

    private void Awake()
    {
        Move_Left();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(monster_Script.nowHp <= 0 && !isDie)
        {
            rigid.velocity = Vector2.zero;
            isDie = true;
        }
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.transform.GetComponent<Battle_Situation_Trigger>())
        {
            rigid.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void Move_Left()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * -1 * speed;
    }
}