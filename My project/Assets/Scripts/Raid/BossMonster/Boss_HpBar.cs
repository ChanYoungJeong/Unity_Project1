using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    public Slider hpSlider;
    public BossStat BossStats;
    [SerializeField]
    float maxHP;
    [SerializeField]
    float nowHP;
  
    void Awake()
    {
        BossStats = this.GetComponent<BossStat>();
    }
    void Update()
    {
        if (BossStats != null)
        {
            maxHP = BossStats.maxHp;
            nowHP = BossStats.nowHp;
            HandleHp();
        }
    }
    private void HandleHp()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)nowHP / (float)maxHP, Time.deltaTime * 10);
    }
}