using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Monster : MonoBehaviour
{

    
    //Monster Group
    public GameObject monster_Group;
    GameObject group;
    private Rigidbody2D group_Rigid;

    Animator Ani;
    //Monster1
    public GameObject monster1_Prefab;
    int monster1_count;
    public bool monster1_Created = false;

    //Stage Information
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!group)
        {
            monster1_Created = false;
        }

        if (monster1_Prefab != null)
        {
            if (!monster1_Created)
            {
                monster1_Created = true;
                Summon_Monster();
            }

        }
    }

    void Summon_Monster()
    {
        if (monster_Group != null && monster1_count == 0)
        {
            group = Instantiate(monster_Group, transform.position, transform.rotation);
            monster1_count = group.GetComponent<Monster_Group_Manager>().numberOfMonster;
        }
        StartCoroutine(Create_Monster1());
    }

    IEnumerator Create_Monster1()
    {
        if (monster1_count > 0)
        {
            GameObject Monster1 = Instantiate(monster1_Prefab, transform.position, transform.rotation);
            Monster1.transform.SetParent(group.transform, true);
            group.GetComponent<Monster_Group_Manager>().checkCoroutine = false;

            yield return new WaitForSeconds(1.0f);
            monster1_count--;
            StartCoroutine(Create_Monster1());
        }
    }
    
}
