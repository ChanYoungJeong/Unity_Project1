using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransHpEXP : MonoBehaviour
{
    public Transform player;
    public Transform hp;
    public Transform exp;

    private void Update()
    {
        hp.position = new Vector3(player.position.x, player.position.y + 2.3f, player.position.z);
        exp.position = new Vector3(player.position.x, player.position.y - 0.6f, player.position.z);
    }

}
