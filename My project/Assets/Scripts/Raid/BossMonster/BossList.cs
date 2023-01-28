using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossList : MonoBehaviour
{
    public Dictionary<string, BossStat> BossStats;

     void Awake()
    {
     BossStats = new Dictionary<string,BossStat>();
        Generate();
    }
     


    void Start()
    {
        
    }
    void Generate()
    {
        string name;

        name = "A";
        BossStats.Add(name, new BossStat(0, name, 5000));
    }
}