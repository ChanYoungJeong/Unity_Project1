using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSummon : MonoBehaviour
{
    public int[] AsderCount;
    //찬영
    public GameObject[] HeroList;
    public Sprite[] HeroImageList;
    private void Awake()
    {

        //전혀 필요없음
        /*
        for(int t=0; t<AsderCount.Length; t++)
        {
            AsderCount[t] = 0;
        }
        */
    }
}
