using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    public Slider hpSlider;
    BossStat BossStats;
    float maxHP;
    float nowHP;

    void Awake()
    {
        BossStats = this.GetComponent<BossStat>();
    }
    void Update()
    {
        maxHP = BossStats.maxHp;
        nowHP = BossStats.nowHp;

        hpSlider.value = (float)nowHP / (float)maxHP;
    }
    private void HandleHp()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)nowHP / (float)maxHP, Time.deltaTime * 10);
    }
}