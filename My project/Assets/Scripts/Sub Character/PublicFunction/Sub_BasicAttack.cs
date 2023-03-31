using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_BasicAttack : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float speed;

    SubCharacterStat subStat;
    Animator animator;

    private bool isAttack = true;

    private void Awake()
    {
        subStat = GetComponent<SubCharacterStat>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SubCharManager.instans.GetTargetPosition(transform);

        if (SubCharManager.instans.CanAttack() && isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttack = false;
        yield return new WaitForSeconds(subStat.atkSpeed);
        isAttack = true;

        animator.SetTrigger("AttackNormal");
        if (prefab != null)
        {
            GameObject PrefabClone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, SubCharManager.instans.angle));
            PrefabClone.GetComponent<Rigidbody2D>().AddForce(PrefabClone.transform.right * speed, ForceMode2D.Impulse);

            //PrefabClone.AddComponent<Dager>();
        }
    }
}
