using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBasicAttack : MonoBehaviour
{
    public GameObject basicAttackPrefab;
    public static GameObject basicAttack;
    Stat playerScript;

    int x;
    Transform playerTrans;
    SubChar_Combat_manager SubStat;

    public bool isCoolTime = true;
    public float speed;

    public Animator subAnimator;

    private void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
        SubStat = this.transform.parent.GetComponent<SubChar_Combat_manager>();
        playerScript = GameObject.Find("Player").GetComponent<Stat>();
    }

    private void Update()
    {
        if (Battle_Situation_Trigger.monster != null || CreateBoss.Bss != null)
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

        else if (this.name == "FireBall")
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

        else if(this.name == "arrow")
        {
            yield return new WaitForSeconds(SubStat.atkSpeed);
            BasicAttack();
            isCoolTime = true;
        }

        else if (this.name == "bottle")
        {
            yield return new WaitForSeconds(SubStat.atkSpeed);
            BasicAttack();
            isCoolTime = true;
        }

        else if (this.name == "IceFang")
        {
            yield return new WaitForSeconds(SubStat.atkSpeed);
            BasicAttack();
            isCoolTime = true;
        }


    }

    public void BasicAttack()
    {
        if (Battle_Situation_Trigger.monster != null || CreateBoss.Bss != null)
        {

            if(this.name == "Dager")
            {
                subAnimator.SetTrigger("AttackNormal");
                CreatePrefab();
            }
            else if(this.name == "FireBall")
            {
                subAnimator.SetTrigger("AttackMagic");
                CreatePrefab();
            }
            else if(this.name == "arrow")
            {
                subAnimator.SetTrigger("AttackBow");
                Invoke("CreatePrefab", 0.7f);
            }
            else if (this.name == "bottle")
            {
                subAnimator.SetTrigger("AttackNormal");
                CreatePrefab();
            }
            else if (this.name == "IceFang")
            {
                subAnimator.SetTrigger("AttackMagic");
                CreatePrefab();
            }
        }
    }

    public void PriestHeal()
    {
        if (playerScript.nowHp < playerScript.maxHp)
        {         
            if(this.name == "Heal")
            {
                subAnimator.SetTrigger("Debuff");
            }
            transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + 1, 0);
            basicAttack = Instantiate(basicAttackPrefab, transform.position, Quaternion.identity);
        }
    }

    public void CreatePrefab()
    {
        float angle = 0;
        if (Battle_Situation_Trigger.monster != null)
        {
            angle = Mathf.Atan2(Battle_Situation_Trigger.monster.transform.position.y - this.transform.position.y,
                                      Battle_Situation_Trigger.monster.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        }
        else if(CreateBoss.Bss != null)
        {

            angle = Mathf.Atan2(CreateBoss.Bss.transform.position.y - this.transform.position.y,
                                      CreateBoss.Bss.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        }


        
        basicAttack = Instantiate(basicAttackPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
        basicAttack.GetComponent<Rigidbody2D>().AddForce(basicAttack.transform.right * speed, ForceMode2D.Impulse);
    }

}