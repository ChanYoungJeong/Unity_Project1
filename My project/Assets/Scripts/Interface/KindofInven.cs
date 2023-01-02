using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KindofInven : MonoBehaviour
{
    public GameObject invenpotion;
    public GameObject inveneqi;
    public GameObject potionbtn;
    public GameObject eqibt;
    // Start is called before the first frame update

    private void Start()
    {
        inveneqi.SetActive(true);
    }


    public void potionopen()
    {
        if (inveneqi.activeSelf == true)
        {
            inveneqi.SetActive(false);
            invenpotion.SetActive(true);
        }
    }
    public void eqiopen()
    {
        if (invenpotion.activeSelf == true)
        {
            invenpotion.SetActive(false);
            inveneqi.SetActive(true);
        }
    }
}
