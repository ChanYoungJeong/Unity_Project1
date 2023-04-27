using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSummon : MonoBehaviour
{
    public int[] AsderCount;
    private void Awake()
    {
        for(int t=0; t<AsderCount.Length; t++)
        {
            AsderCount[t] = 0;
        }
    }
}
