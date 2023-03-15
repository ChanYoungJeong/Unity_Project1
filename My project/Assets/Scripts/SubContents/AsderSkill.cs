using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsderSkill : MonoBehaviour
{

    GameObject enemy;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Monster")
        {
            enemy = collision.gameObject;
            Destroy(enemy);

        }
    }
}
