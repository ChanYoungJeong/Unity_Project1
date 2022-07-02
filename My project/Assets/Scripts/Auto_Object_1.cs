using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Object_1 : MonoBehaviour
{
    public int Auto1_iMoney = 0;
    public float wait_time = 2.0f;
    private int check = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (check == 0)
        {
            check = 1;
            StartCoroutine(WaitForIt());
        }
    }

   IEnumerator WaitForIt()
    {
        Auto1_iMoney += 3;
        yield return new WaitForSeconds(wait_time);    
        check = 0;
    }
}
