using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player_script : MonoBehaviour
{
    [Header ("player stats")]
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public bool attacked;

    [Header ("commons")]
    public Image nowHpbar;


    private void Start()
    {
        atkDmg = 10;
        attacked = false;
        maxHp = 100;
        nowHp = 100;

    }

    private void Update()
    {
        // nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }


}
