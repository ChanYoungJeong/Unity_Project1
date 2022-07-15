using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Monster : MonoBehaviour
{
    public float speed = 3.0f;
    
    //Monster Group
    public GameObject Monster_Group;
    GameObject Group;
    private Rigidbody2D Group_Rigid;

    //Monster1
    public GameObject Monster1_Prefab;
    public int Monster1_count = 3;
    bool Monster1_Created = false;
    private Rigidbody2D Monster1_Rigid;

    // Start is called before the first frame update
    void Start()
    {
        Group = Instantiate(Monster_Group, transform.position, transform.rotation);
        Group_Rigid = Group.GetComponent<Rigidbody2D>();
        Monster1_Rigid.velocity = transform.right * -1 * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster1_Prefab != null)
        {
            if (!Monster1_Created)
            {
                StartCoroutine(Create_Monster1());
                Monster1_Created = true;
            }
        }
    }

    IEnumerator Create_Monster1()
    {
        if (Monster1_count > 0)
        {
            GameObject Monster1 = Instantiate(Monster1_Prefab, transform.position, transform.rotation);
            Monster1.transform.SetParent(Group.transform, true);
            Monster1_Rigid = Monster1.GetComponent<Rigidbody2D>();
            Monster1_Rigid.velocity = transform.right * -1 * speed;

            yield return new WaitForSeconds(1.0f);
            Monster1_count--;
            StartCoroutine(Create_Monster1());
        }
    }

    
}
