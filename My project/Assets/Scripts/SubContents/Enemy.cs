using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int monsterTpye;
    public float maxHp;
    public float nowHp;
    public float dmg;
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable()
    {
        target = ContentsManager.instans.player.GetComponent<Rigidbody2D>();
        SetStat();
    }

    void SetStat()
    {
        monsterTpye = this.name == "EnemyA(Clone)" ? 0 : 1;

        if (monsterTpye == 0)
        {
            maxHp = 10f;
            nowHp = 10f;
            dmg = 1f;
        }
        else
        {
            maxHp = 15f;
            nowHp = 15f;
            dmg = 1f;
        }
    }
}
