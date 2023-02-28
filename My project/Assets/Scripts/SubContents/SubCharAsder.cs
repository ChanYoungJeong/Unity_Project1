using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharAsder : MonoBehaviour
{
    public GameObject Player;
    public GameObject archer;
   
    

    public void ArcherSkill()
    {
        Vector3 mainpos;
        mainpos = Player.transform.position;
        archer.transform.position = mainpos;

        float scaleX = archer.transform.localScale.x;
        float scaleY = archer.transform.localScale.y;
        float scaleZ = archer.transform.localScale.z;
        archer.transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);

        archer.SetActive(true);

          
    }
}
