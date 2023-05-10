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
    public int scale;
    public GameObject Monster;
    public int CurrentStage;


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

        if (Game_System.Stage % CurrentStage == 0)
        {
            ChamgePrefabs();
        }
    }

    public void ChamgePrefabs()
    {
        monster_Prefab = Resources.Load("Prefabs\\Enemy2") as GameObject;
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
         Monster = Instantiate(monster_Prefab, spawnArray[range].position, transform.rotation);
        setMonsterStat(Monster);
        Monster.transform.SetParent(this.transform, true);    
    }

    void setMonsterStat(GameObject monster)
    {
        Monster_Manager MM;
        MM = monster.GetComponent<Monster_Manager>();
        MM.scale = scale;
    }
}
