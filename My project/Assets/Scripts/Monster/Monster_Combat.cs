using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Combat : MonoBehaviour
{
    Monster_Script Monster_Stat;
    PlayerScript Player_Stat;
    Animator anim;

    public Transform DamagePrinter;
    public GameObject DamageText;
    public GameObject CriticalDamageText;

    bool check = false;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("isattack", false);
    }
    void Start()
    {
        Player_Stat = GameObject.Find("Player").GetComponent<PlayerScript>();
        Monster_Stat = this.GetComponent<Monster_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle_Situation_Trigger.on_Battle)
        {
            if (Player_Stat && !check)
            {
                check = true;
                StartCoroutine(Attack());
            }
        }
        else
        {
            StopCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Monster_Stat.atkSpeed);
        anim.SetBool("isattack", true);
        Player_Stat.nowHp -= Monster_Stat.atkDmg;
        Debug.Log("Monster Attack, Player Hp = " + Player_Stat.nowHp);
    }

    public void ApplyDamage(float damage, Color color, float ciritcalRate, float criticalDamage)
    {
        if (Random.Range(0, 100) < ciritcalRate)
        {
            Monster_Stat.nowHp -= Mathf.RoundToInt(damage * criticalDamage);
            GameObject hudText = Instantiate(CriticalDamageText);
            hudText.transform.position = DamagePrinter.position;
            hudText.GetComponent<DamageText>().damage = Mathf.RoundToInt(damage * criticalDamage);
            hudText.GetComponent<DamageText>().damageColor = color;
        }
        else
        {
            Monster_Stat.nowHp -= damage;
            GameObject hudText = Instantiate(DamageText);
            hudText.transform.position = DamagePrinter.position;
            hudText.GetComponent<DamageText>().damage = damage;
            hudText.GetComponent<DamageText>().damageColor = color;
        }
    }


}
