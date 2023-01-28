using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{

    public static GameObject Bss;
    public GameObject BBss;
    
    void Start()
    {
        CreateBossMonsterA();
    }

    void Update()
    {
        
    }

    public void CreateBossMonsterA()
    {
        Bss = Instantiate(BBss,transform.position,Quaternion.identity);
    }
}