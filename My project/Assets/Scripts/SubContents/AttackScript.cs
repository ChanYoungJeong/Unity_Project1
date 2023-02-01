using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    GameObject enemy;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Monster")
        {
            enemy = collision.gameObject;
            float hp = enemy.GetComponent<Enemy>().nowHp -= ContentsManager.instans.player.atkDmg;

            if (hp <= 0)
            {
                hp = 0;
                Destroy(enemy);
            }
        }
    }
}
