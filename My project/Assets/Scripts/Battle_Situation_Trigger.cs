using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Situation_Trigger : MonoBehaviour
{
    bool log_check = false;
    public static bool On_Battle = false;
    public static GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            Monster = collision.gameObject;
            On_Battle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            On_Battle = false;
            Debug.Log(On_Battle);
        }
    }
}
