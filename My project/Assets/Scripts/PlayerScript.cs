using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    [Header ("player stats")]
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public bool attacked;
    public float atkSpeed;

    [Header ("commons")]
    public Image nowHpbar;


    public GameObject attackRange;              //플레이어가 죽으면 setactive(false); 한다 

    private void Start()
    {
        atkDmg = 10;
        attacked = true;
        maxHp = 100;
        nowHp = 100;
        atkSpeed = 1.0f;

    }

    private void Update()
    {
        // nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }

    private void SetAttack()
    {
        attacked = true;
    }
}
