using Amazon.DynamoDBv2.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCombat : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    Stat Stat;
    InstantiatePrefab instantiatePrefab;

    private bool isAttack = true;

    private void Awake()
    {
        Stat = GetComponent<Stat>();
        instantiatePrefab = GetComponent<InstantiatePrefab>();
    }

   private void Update()
    {
        if (isAttack)
        {
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        isAttack = false;
        yield return new WaitForSeconds(Stat.sub_atkSpeed);
        isAttack = true;

        instantiatePrefab.CreatePrefab(prefab);
    }

}
