using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTMonster : MonoBehaviour
{
    public GameObject tMonster;

    private void Start()
    {
        TmonsterCeate();
    }

    public void TmonsterCeate()
    {
        GameObject tmonsterClone = Instantiate(tMonster, transform.position, Quaternion.identity);
        tmonsterClone.GetComponent<Rigidbody2D>().position = new Vector3(-1, 0);
    }
}
