using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player_script : MonoBehaviour
{
    //플레이어 스탯
    private float Player_offensive_Power = 10f;
    private float Attack_Delay = 1f;

    //체력바 스탯
    public float maxHp;
    public float curHp;
    public Slider HP_bar;


    public bool isDead { get; private set; } = false;

    private Color color;
    private SpriteRenderer spriteRenderer;


 
    
    void Start()
    {
        HP_bar = GetComponent<UI>().HP_bar;
        maxHp = GetComponent<UI>().maxHp;
        curHp = GetComponent<UI>().curHp;
        HP_bar.value = curHp / maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = Color.red;
        //몬스터와 충돌할 때 몬스터 체력바 플레이어 공격력 만큼 감소 (1초 주기)

        InvokeRepeating("HandleHp", 1f, Attack_Delay);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }
    */

     private void OnCollisionStay2D(Collision2D collision)
     {
        
    }
   

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (check == 0)
        {
            check = 1;
            StartCoroutine(WaitForIt());
        }
    }
    */

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
    */

    private void HandleHp()
    {
        if (curHp >= 0) { 
        curHp -= Player_offensive_Power;
        HP_bar.value = Mathf.Lerp(HP_bar.value, curHp / maxHp, Time.deltaTime * 10);
        }
    }

}
