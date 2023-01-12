using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster_Script : MonoBehaviour
{
    BossStat BStat;
    BossList BList;

    public float maxHp;
    public float nowHp;
    public string _name;

    void Start()
    {
        BStat = GameObject.Find("SetBossMonster").GetComponent<BossStat>();
        BList = GameObject.Find("SetBossMonster").GetComponent<BossList>();
        SetBossStat();
    }

    void Update()
    {
        
    }

    public void SetBossStat()
    {
        bool isFind = BList.BossStats.ContainsKey(this.name);
        Debug.Log(isFind);
        if (isFind)
        {
            BStat = BList.BossStats[this.name];

            maxHp = BStat.maxHp;
            nowHp = BStat.maxHp;
            _name = BStat.name;
        }
    }
}
