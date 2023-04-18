using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetAsderBead : MonoBehaviour
{
    public AsderCall AsderCount;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player(SubContent)")
        {
            AsderCount.BeadCount++;
            
            //AsderCount.BeadCount = index;
            Destroy(this.gameObject);
        }

    }
   
}
