using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Monster : MonoBehaviour
{
    private Rigidbody2D rigid;
    public bool monster_Stop = false;

    public PlayerScript playerScript;
    public Monster monster;
    public Game_System gameSystem;
    int count;
    private float attckSpeed = 1.0f;

    //Battle_Situation_Trigger

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        monster = Battle_Situation_Trigger.monster.GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            Debug.Log("current Monster " + Battle_Situation_Trigger.monster.name);
            rigid.velocity = Vector2.zero;
            monster_Stop = true;

            StartCoroutine(PlayerAttack());
        }
        else
        {
            monster_Stop = false;
        }
    }


    IEnumerator PlayerAttack()
    {
        while (true)
        {
            if (monster.nowHp > 0)
            {
                monster.nowHp -= playerScript.atkDmg;
                Debug.Log(monster.nowHp);

            }
            else
            {
                Destroy(monster.gameObject);
                Destroy(monster.hpBar.gameObject);
                count +=30;
                gameSystem.Gold += 100 * count;
                Debug.Log(gameSystem.Gold);
                break;
            }
            yield return new WaitForSeconds(attckSpeed);
        }
    }
}