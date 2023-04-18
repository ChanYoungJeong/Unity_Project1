using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCon_AttackScript : MonoBehaviour
{
    //public GameObject Weapon;
    GameObject enemy;
    Animator Anim;
    Stat stat;
    private void Awake()
    {
        Anim = GetComponentInParent<Animator>();
        stat = GetComponentInParent<Stat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = stat.atkDamage;
        float criticalRate = stat.criticalRate;
        if (collision.gameObject.GetComponent<Monster_Script>() && Anim.GetBool("AttackNormal"))
        {
            collision.GetComponent<Monster_Combat>().ApplyDamage(damage, Color.red, criticalRate, 1.2f);
        }
    }

    public void ActiveAttack()
    {
        Anim.SetBool("AttackNormal", true);
    }

    public void DeActiveAttack()
    {
        Anim.SetBool("AttackNormal", false);
    }
}
