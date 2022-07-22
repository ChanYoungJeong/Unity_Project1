using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public PlayerScript playerScript;
    public Game_System gameSystem;
    int count = 1;

    private float attckSpeed = 1.0f;




    private void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Monster"))
        {

            if (playerScript.attacked)                                     // 플레이어 공격 활성화(Enable Player Attacks)
            {
                StartCoroutine(PlayerAttack(collision.GetComponent<Monster_Script>()));                           // 몬스터 현재 체력 감소
                        
                playerScript.attacked = false;                                                         // 플레이어 공격 비활성화 (Disable Player Attacks)
            }
        }
    }

    IEnumerator PlayerAttack(Monster_Script monster)
    {
        while (true)
        {
            if (monster.nowHp > 0)
            {
                monster.nowHp -= playerScript.atkDmg;
                EventManager.SendEvent("Sound :: Create 2D", "Click", 1f);
                Debug.Log(monster.nowHp);

            }
            else
            {
                Destroy(monster.gameObject);
                Destroy(monster.hpBar.gameObject);
                count++;
                break;
            }
            yield return new WaitForSeconds(attckSpeed);
        }
    }
}
