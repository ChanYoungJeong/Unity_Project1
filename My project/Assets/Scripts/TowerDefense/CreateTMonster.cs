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

    private void Update()
    {

    }

    public void TmonsterCeate()
    {  
        GameObject tmonsterClone = Instantiate(tMonster, transform.position, Quaternion.identity);
    }
}
