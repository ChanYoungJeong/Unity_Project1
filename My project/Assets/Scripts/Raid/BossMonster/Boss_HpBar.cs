using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    public Slider hpSlider;
    Monster_Script bossScript;
    float maxHP;
    float nowHP;

    void Awake()
    {
        bossScript = GetComponent<Monster_Script>();
    }
    void Update()
    {
        hpSlider.transform.position = new Vector3(transform.position.x, transform.position.y + 9.2f, transform.position.z); ;

        maxHP = bossScript.maxHp;
        nowHP = bossScript.nowHp;
        HandleHp();
    }
    private void HandleHp()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)nowHP / (float)maxHP, Time.deltaTime * 10);
    }
}