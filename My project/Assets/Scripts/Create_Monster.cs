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

    //Monster1
    public GameObject monster1_Prefab;
    public int monster1_count = 3;
    bool monster1_Created = false;


    // Start is called before the first frame update
    void Start()
    {
        if (monster_Group != null)
        {
            group = Instantiate(monster_Group, transform.position, transform.rotation);
            group_Rigid = group.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monster1_Prefab != null)
        {
            if (!monster1_Created)
            {
                StartCoroutine(Create_Monster1());
                monster1_Created = true;
            }
        }
    }

    IEnumerator Create_Monster1()
    {
        if (monster1_count > 0)
        {
            GameObject Monster1 = Instantiate(monster1_Prefab, transform.position, transform.rotation);
            Monster1.transform.SetParent(group.transform, true);


            yield return new WaitForSeconds(1.0f);
            monster1_count--;
            StartCoroutine(Create_Monster1());

        }
    }

    
}
