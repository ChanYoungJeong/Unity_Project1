using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDestroy : MonoBehaviour
{
    public GameObject archerskill;

    private void Start()
    {
        Archerskill();
        Invoke("DestroyScript", 1.0f);
    }

    void Archerskill()
    {
        int speed = 20;
        float angle = 0;
        //ArcherAsder.transform.position=new Vector3(0,0,angle);
        //  ġ  


        /*angle = Mathf.Atan2(Battle_Situation_Trigger.monster.transform.position.y - this.transform.position.y,
                Battle_Situation_Trigger.monster.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;*/


        GameObject ArcherAsder = Instantiate(archerskill, transform.position, Quaternion.identity);

        ArcherAsder.GetComponent<Rigidbody2D>().AddForce(ArcherAsder.transform.right * speed, ForceMode2D.Impulse);

        Destroy(ArcherAsder, 2.0f); //      ʰ       ڵ 
    }

    void DestroyScript()
    {
        Destroy(gameObject);
    }
}
