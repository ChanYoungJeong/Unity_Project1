using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharPassive : MonoBehaviour
{
    public SubCharSetting charSetting;

    public GameObject sibal;

    public Animator Subanimator;

    private void Start()
    {
        charSetting = GameObject.Find("SubCharSetting").GetComponent<SubCharSetting>();
    }
    private void Update()
    {
        if (charSetting.player_LEVEL >= 50)
        {
            PlusSkill();
        }
    }

    public void PlusSkill()
    {
        //패시브 스킬 추가
        //공격도 ㄱㅊ
       
    }
}
