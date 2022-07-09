using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player_script : MonoBehaviour
{
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public bool attacked = false;
    public Image nowHpbar;

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }

    private void Start()
    {
        atkDmg = 10;

    }

    private void Update()
    {
        // nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }


}
