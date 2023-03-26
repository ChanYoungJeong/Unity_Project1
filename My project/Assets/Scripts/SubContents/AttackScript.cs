using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    GameObject enemy;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Monster_Script>())
        {
            enemy = collision.gameObject;
            enemy.GetComponent<Monster_Combat>().ApplyDamage(25, Color.red, 20, 1.2f);
        }
    }
}
