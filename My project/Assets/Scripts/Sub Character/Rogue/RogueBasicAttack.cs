using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBasicAttack : MonoBehaviour
{
    private GameObject daggerPrefab;
    private Animator animator;
    private SubCharacterStat subStat;


    [SerializeField] private float speed = 20f;

    private bool isAttack = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        subStat = GetComponent<SubCharacterStat>();

    }

    private void Start()
    {
        daggerPrefab = Resources.Load<GameObject>("Prefabs/Skills/SubChar/SkillObject/Re_dager");
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
        if (daggerPrefab != null)
        {
            GameObject dagerPrefabClone = Instantiate(daggerPrefab, transform.position, Quaternion.Euler(0, 0, SubCharManager.instans.angle));
            dagerPrefabClone.GetComponent<Rigidbody2D>().AddForce(dagerPrefabClone.transform.right * speed, ForceMode2D.Impulse);

            dagerPrefabClone.AddComponent<Dager>();
        }
    }

}
