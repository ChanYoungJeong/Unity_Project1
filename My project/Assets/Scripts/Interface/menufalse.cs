using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menufalse : MonoBehaviour
{
   public GameObject gameObject1; 
   public GameObject gameObject2;
   public GameObject gameObject3;
   public GameObject gameObject4;
   

public void onoff()
    {
        if (gameObject3.activeSelf==true)
        {
            gameObject1.SetActive(false);
            gameObject2.SetActive(false);
        }
        else if (gameObject1.activeSelf==true && gameObject2.activeSelf==true)
        {
            gameObject3.SetActive(false);
        }
    }
}
