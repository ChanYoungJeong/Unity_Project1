using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharSetActive : MonoBehaviour
{
    public GameObject Rogue;

    public void RogueSetActive()
    {
        if(Rogue.activeSelf == true)
        {
            Rogue.SetActive(false);
        }
        else
        {
            Rogue.SetActive(true);
        }
    }

}
