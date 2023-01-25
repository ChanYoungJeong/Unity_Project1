using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{

    public static GameObject sibal;
    public GameObject ssibal;
    
    void Start()
    {
        CreateBossMonsterA();
    }

    void Update()
    {
        
    }

    public void CreateBossMonsterA()
    {
        sibal = Instantiate(ssibal,transform.position,Quaternion.identity);
    }
}