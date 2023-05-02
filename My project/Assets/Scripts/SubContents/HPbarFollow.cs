using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbarFollow : MonoBehaviour
{
    public GameObject Hpbar;
    public float underbar;
    void Update()
    {
        Hpbar.transform.position = new Vector3(transform.position.x, transform.position.y-underbar, transform.position.z);
    }
}
