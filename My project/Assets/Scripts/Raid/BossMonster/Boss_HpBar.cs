using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    Slider hpSlider;
    BossMonster_Script bossScript;
    float maxHP;
    float nowHP;
  
    void Awake()
    {
        bossScript = GetComponent<BossMonster_Script>();
        hpSlider = GameObject.Find("BossHpBar").GetComponent<Slider>();
    }
    void Update()
    {
        maxHP = bossScript.maxHp;
        nowHP = bossScript.nowHp;
        HandleHp();
    }
    private void HandleHp()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)nowHP / (float)maxHP, Time.deltaTime * 10);
    }
}