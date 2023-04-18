using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int monsterTpye;
    public float speed = 1.0f;
    private Rigidbody2D target;
    private Monster_Script stat;
    bool contentCheck = true;

    Rigidbody2D rigid;
    public SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }




    private void OnCollisionStay2D(Collision2D collision)
    {
            if (collision.gameObject.GetComponent<PlayerScript>() && contentCheck)
            {
                collision.gameObject.GetComponent<Stat>().nowHp -= stat.atkDmg;
                contentCheck = false;
                StartCoroutine(contentAttack());
          }
    }

    IEnumerator contentAttack()
    {
        yield return new WaitForSeconds(stat.atkSpeed);

        contentCheck = true;
    }
}
