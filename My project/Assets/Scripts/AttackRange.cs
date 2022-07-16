using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public PlayerScript playerScript;


    private void Update()
    {
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Monster"))
        {
            Debug.Log("collision AttackRange");

            if (playerScript.attacked)                                     // �÷��̾� ���� Ȱ��ȭ(Enable Player Attacks)
            {
                Debug.Log("Attack action");
                Debug.Log("atkDmg : " + playerScript.atkDmg);

                StartCoroutine(PlayerAttack(collision.GetComponent<Monster>()));                           // ���� ���� ü�� ����
                        
                playerScript.attacked = false;                                                         // �÷��̾� ���� ��Ȱ��ȭ (Disable Player Attacks)
            }
        }
    }

    IEnumerator PlayerAttack(Monster monster)
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
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
