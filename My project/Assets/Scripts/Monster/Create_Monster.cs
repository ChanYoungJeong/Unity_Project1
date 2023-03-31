using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Monster : MonoBehaviour
{

    //Monster
    public GameObject monster_Prefab;
    public int monster1_count;
    public Transform[] spawnArray;
    public int monsterCapacity = 3;
    [SerializeField]
    float summonDelay = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonMonsterWithDelay());
    }

    private void Update()
    {
        if(this.transform.childCount == 0)
        {
            Destroy(gameObject, Game_System.StageDelay);
        }
    }

    IEnumerator SummonMonsterWithDelay()
    {
        for (int i = 0; i < monsterCapacity; i++)
        {
            generateMonster();
            yield return new WaitForSeconds(summonDelay);       
        }   
        StopCoroutine(SummonMonsterWithDelay());
    }

    void generateMonster()
    {
        int range = Random.Range(0, 8);
        GameObject Monster = Instantiate(monster_Prefab, spawnArray[range].position, transform.rotation);
        Monster.transform.SetParent(this.transform, true);
    }
}
