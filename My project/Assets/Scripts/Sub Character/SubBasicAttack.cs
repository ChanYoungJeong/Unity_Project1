using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    Monster_Script monsterStatus;

    PlayerScript playerstatHP;

    public GameObject basicAttackPrefab;
    GameObject dager;
    GameObject Heal;

    SubChar_Combat_manager rogueStat;

    bool isAttack = true;
    public float speed;

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            monsterStatus = Battle_Situation_Trigger.monster_group.transform.GetChild(0).GetComponent<Monster_Script>(); // ����������?��? ������?���� ???����? ??

            if (isAttack)
            {
                //StartCoroutine(Attack());
            }
        }
    }
    public IEnumerator Attack()
    {
        while(isAttack)
        {
            isAttack = false;
            RogueBasicAttack();
            Debug.Log(rogueStat.atkSpeed);
            yield return new WaitForSeconds(rogueStat.atkSpeed);
            isAttack = true;
            Debug.Log(isAttack);
        }
    }

    public void RogueBasicAttack()
    {
        dager = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
        dager.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Impulse);
        //���� �߽� ���� ����°� �����ϱ�

        Heal = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);

    }

}
