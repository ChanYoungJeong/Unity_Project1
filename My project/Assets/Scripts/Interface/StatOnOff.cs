using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatOnOff : MonoBehaviour
{
    [SerializeField] GameObject HeroStat;
    
    void Start()
    {
        HeroStat.SetActive(false);
    }

    public void OnOff()
    {
        bool Stat = HeroStat.activeSelf;
        HeroStat.SetActive(!Stat);
    }
}
