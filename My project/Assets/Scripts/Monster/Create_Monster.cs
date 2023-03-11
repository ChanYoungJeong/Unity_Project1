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
    public int monster1_count;
    public bool monster1_Created = false;
    public Transform[] spawnArray;

    float time = 0;
    //Stage Information


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        if (!Battle_Situation_Trigger.on_Battle)
        {
            monster1_Created = false;

        }
       if (!monster1_Created)
       {
           monster1_Created = true;
           Summon_Monster();
       }

        time += Time.deltaTime;
    }

    void Summon_Monster()
    {
        if (monster_Group != null && monster1_count == 0)
        {
            group = Instantiate(monster_Group, transform.position, transform.rotation);
            monster1_count = group.GetComponent<Monster_Group_Manager>().numberOfMonster;
            StartCoroutine(Create_Monster1());
        }
        
    }

    public IEnumerator Create_Monster1()
    {
        while (monster1_count > 0 && monster1_Created)
        {
            Invoke("MakeMonster", 0f);
            Invoke("MakeMonster", 0.3f);
            Invoke("MakeMonster", 0.6f);
            yield return new WaitForSeconds(2.0f);
            monster1_count--;
        }
    }

    void MakeMonster()
    {
        int range = Random.Range(0, 8);
        GameObject Monster1 = Instantiate(monster1_Prefab, spawnArray[range].position, transform.rotation);
        Monster1.transform.SetParent(group.transform, true);
        if (Game_System.Stage >= 2 && Game_System.Stage<20)
        {
            Monster1.GetComponentInChildren<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(
                Resources.Load("Ani\\Idle_0", typeof(RuntimeAnimatorController)));
        }
        group.GetComponent<Monster_Group_Manager>().checkCoroutine = false;
    }

}
