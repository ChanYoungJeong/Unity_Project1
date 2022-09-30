using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    public GameObject basicAttackPrefab;
    public static GameObject dager;

    SubChar_Combat_manager rogueStat;

    bool isCoolTime = true;
    public float speed;

    private void Start()
    {
        rogueStat = this.transform.parent.GetComponent<SubChar_Combat_manager>();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            if (isCoolTime)
            {
                StartCoroutine(Attack());
                StopCoroutine(Attack());

            }
        }

    }
    public IEnumerator Attack()
    {
        isCoolTime = false;
        if (this.name == "Dager")
        {
            yield return new WaitForSeconds(rogueStat.atkSpeed);
            RogueBasicAttack();
            isCoolTime = true;

        }
         //else if(this.name == "�Ű� �⺻����"){}
    }

    public void RogueBasicAttack()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            dager = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
            dager.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Impulse);
            //���� �߽� ���� ����°� �����ϱ�
        }
    }
}
