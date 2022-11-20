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

    GameObject[] gameObjectsArr;

    public void onoff()
    {
        if (gameObject3.activeSelf == true)
        {
            gameObject1.SetActive(false);
            gameObject2.SetActive(false);
        }
        else if (gameObject1.activeSelf == true && gameObject2.activeSelf == true)
        {
            gameObject3.SetActive(false);
        }
    }

    private void allOff()
    {
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
        gameObject4.SetActive(false);
    }

    void gameObject2OnOff()
    {
        allOff();
        gameObject2.SetActive(true);

        //for(gameObjectsArr[1] ~ [n]){
        //if(gameObjectArr[i].activeself == true)
        //gameObjectArr[i].SetActive(false);
        //}
        //gameObject2.SetActive(true);
    }
}
