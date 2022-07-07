using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Monster : MonoBehaviour
{
    private Rigidbody2D Rigid;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.CompareTag("Player"))
        {
            Rigid.velocity = Vector2.zero;
        }
    }
}
