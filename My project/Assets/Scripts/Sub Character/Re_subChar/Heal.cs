using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    Stat stat;
    public float healAmount;
    public float destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Stat>())
        {
            stat = collision.gameObject.GetComponent<Stat>();
            if(stat.nowHp < stat.maxHp)
                stat.nowHp += healAmount;
            if (stat.nowHp > stat.maxHp)
                stat.nowHp = stat.maxHp;

        }
    }
}
