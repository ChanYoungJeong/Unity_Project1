using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static GameObject boss;


    private void Awake()
    {
        boss = this.gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
