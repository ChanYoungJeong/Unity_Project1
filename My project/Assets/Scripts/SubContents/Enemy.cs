using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int monsterTpye;
    public float speed = 1.0f;
    private Rigidbody2D target;
    private Monster_Script stat;

    bool isLive = true;
    bool canAttack = true;

    Rigidbody2D rigid;
    public SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //spriter = transform.GetComponent<SpriteRenderer>();
        stat = GetComponent<Monster_Script>();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {

        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable()
    {
        target = ContentsManager.instans.player.GetComponent<Rigidbody2D>();
        SetStat();
    }

    void SetStat()
    {
        stat.maxHp = 40;
        stat.nowHp = 40;
        stat.atkDmg = 1;
        stat.atkSpeed = 1.2f;
    }

}
