using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{

    public static GameObject Bss;
    public GameObject BBss;
    public GameObject HpBar;
    
    
    void Start()
    {
        
    }

    public void CreateBossMonsterA()
    {
        Bss = Instantiate(BBss, transform.position,Quaternion.identity);
        GameObject hp = Instantiate(HpBar, transform.position, Quaternion.identity);

        hp.transform.position = new Vector3(Bss.transform.position.x, Bss.transform.position.y + 10, Bss.transform.position.z);
    }

}