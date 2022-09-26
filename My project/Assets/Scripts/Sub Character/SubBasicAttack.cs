using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    public GameObject basicAttackPrefab;
    public static GameObject dager;

    SubChar_Combat_manager rogueStat;

    bool isAttack = true;
    public float speed;

    private void Start()
    {
        rogueStat = this.transform.parent.GetComponent<SubChar_Combat_manager>();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            if (isAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }
    public IEnumerator Attack()
    {
        while(isAttack)
        {
            isAttack = false;
            if (this.name == "Dager")
            {


                RogueBasicAttack();
                yield return new WaitForSeconds(rogueStat.atkSpeed);
            }
            //else if(this.name == "신관 기본공격"){}

            isAttack = true;
        }
    }

    public void RogueBasicAttack()
    {
        dager = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
        dager.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Impulse);
        //몬스터 중심 향해 날라는거 구현하기
    }

}
