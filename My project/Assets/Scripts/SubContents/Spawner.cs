using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ContentsManager content;
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    Transform[] spawnPoint;
    float timer;
    float incrementTime;
    [Header("Monster Stat Setting")] 
    public float HP;
    public float damage;
    public float Exp;
    public float increment;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (content.startContent)
        {
            timer += Time.deltaTime;
            incrementTime += Time.deltaTime;
        }

        if(timer > 1f)
        {
            timer = 0f;
            Spawn();
        }

        if(incrementTime > 10f)
        {
            increaseStat();
            incrementTime = 0f;
        }
    }

    void Spawn()
    {
        GameObject enemy = Get(Random.Range(0, pools.Length));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        SetStat(enemy.GetComponent<Monster_Script>());
    }

    GameObject Get(int index)
    {
        GameObject select = Instantiate(prefabs[index], transform);
        pools[index].Add(select);
        
        return select;
    }

    void SetStat(Monster_Script monsterStat)
    {
        monsterStat.maxHp = HP;
        monsterStat.nowHp = HP;
        monsterStat.atkDmg = damage;
        monsterStat.atkSpeed = 1.0f;
        monsterStat.Exp = (int)Exp;
    }

    void increaseStat()
    {
        HP *= increment;
        damage *= increment;
        Exp *= increment;
    }

}
