using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Click_Script : MonoBehaviour
{
    public int iMoney;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Add_Money(); //
        }
    }


    void Add_Money()
    {
        iMoney++;
        Debug.Log(iMoney);
    }
}
