using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    public GameObject basicAttackPrefab;
    public static GameObject basicAttack;

    GameObject Player;

    Transform playerTrans;
    SubChar_Combat_manager SubStat;

    bool isCoolTime = true;
    public float speed;

    private void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
        SubStat = this.transform.parent.GetComponent<SubChar_Combat_manager>(); 
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            if (isCoolTime)
            {
                StartCoroutine(Attack());

            }
        }
    }
    public IEnumerator Attack()
    {
        isCoolTime = false;
        StopCoroutine(Attack());
        if (this.name == "Dager")
        {
            yield return new WaitForSeconds(SubStat.atkSpeed);
            BasicAttack();
            isCoolTime = true;

        }
        
        else if(this.name == "FireBall") 
        {
            yield return new WaitForSeconds(SubStat.atkSpeed);
            BasicAttack();
            isCoolTime = true;
        }

        else if (this.name == "Heal")
        {       
            yield return new WaitForSeconds(SubStat.atkSpeed);
            PriestHeal();
            isCoolTime = true;
        }
    }

    public void BasicAttack()
    {
        if (Battle_Situation_Trigger.monster != null)
        {
            basicAttack = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
            basicAttack.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Impulse);
            //몬스터 중심 향해 날라는거 구현하기
        }
    }
    public void PriestHeal()
    {
        transform.position = new Vector3(-3.78f, 0, 0);
        basicAttack = Instantiate(basicAttackPrefab, playerTrans.transform.position, Quaternion.identity);
    }
}