using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Combat : MonoBehaviour
{
    Monster_Script Monster_Stat;
    Stat Player_Stat;

    Animator anim;

    public Transform DamagePrinter;
    public GameObject DamageText;
    public GameObject CriticalDamageText;
    Stop_Monster stopmoster;
    float y;
    // Start is called before the first frame update
    void Awake()
    {
        stopmoster= GetComponent<Stop_Monster>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        if (GameObject.Find("Player"))
        {
            GameObject Player = GameObject.Find("Player");
            Player_Stat = Player.GetComponent<Stat>();
        }
        Monster_Stat = this.GetComponent<Monster_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            if (Player_Stat && stopmoster.stop)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            StopCoroutine(Attack());
        }
        if (!stopmoster.stop)
        {
            anim.SetTrigger("Run");
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Monster_Stat.atkSpeed);
        anim.SetTrigger("Attack");
        Player_Stat.nowHp -= Monster_Stat.atkDmg;
    }

    public void ApplyDamage(float damage, Color color, float ciritcalRate, float criticalDamage)
    {
        if (y == 0)
            StartCoroutine(sety(1.0f));
        if (Random.Range(0, 100) < ciritcalRate)
        {
            Monster_Stat.nowHp -= Mathf.RoundToInt(damage * criticalDamage);
            GameObject hudText = Instantiate(CriticalDamageText);
            hudText.transform.position = DamagePrinter.position + new Vector3(0, y, 0);
            hudText.GetComponent<DamageText>().damage = Mathf.RoundToInt(damage * criticalDamage);
            hudText.GetComponent<DamageText>().damageColor = color;
        }
        else
        {
            Monster_Stat.nowHp -= damage;
            GameObject hudText = Instantiate(DamageText);
            hudText.transform.position = DamagePrinter.position + new Vector3(0, y, 0);
            hudText.GetComponent<DamageText>().damage = damage;
            hudText.GetComponent<DamageText>().damageColor = color;
        }
        y += 0.5f;
    }

    IEnumerator sety(float delay)
    {
        yield return new WaitForSeconds(delay);
        y = 0;
    }

}
