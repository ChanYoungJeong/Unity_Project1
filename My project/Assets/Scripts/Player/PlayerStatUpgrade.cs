using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatUpgrade : MonoBehaviour
{
    public Stat CharacterStat;
    /*
    public TextMeshProUGUI lv;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI skillDamage;
    public TextMeshProUGUI criticalRate;
    public TextMeshProUGUI SkillCollDown;
    */
    //New
    public Transform statTextHolder;
    //귀찮아서 임시로 설정
    //지금은 index로 관리하나 추후에 위에 주석 처리해놓은거 처럼 따로따로 연결해도 무관
    [Tooltip("체력/데미지/스킬데미지/크리티컬율/크리티컬 데미지 순서대로 놓아야한다")]
    public TextMeshProUGUI[] statText;
    public Transform upStatTextHolder;
    public TextMeshProUGUI[] upStatText;
    public int upgradeCost;
    public Text goldText;
    public int UpgradeStat;
    //new write
    public int BuyGold;
    public int NeedLevel;


    public void Awake()
    {
        statText = statTextHolder.GetComponentsInChildren<TextMeshProUGUI>();
        upStatText = upStatTextHolder.GetComponentsInChildren<TextMeshProUGUI>();
        goldText.text = upgradeCost.ToString();
        setStatDisplay();
        setUpstatDisplay();
    }

    void setStatDisplay()
    {
        statText[0].text = "HP : " + CharacterStat.maxHp.ToString();
        statText[1].text = "Damage : " + CharacterStat.atkDamage.ToString();
        statText[2].text = "Skill Damage : " + CharacterStat.skillDamage.ToString();
        statText[3].text = "Critical Rate : " + CharacterStat.criticalRate.ToString();
        statText[4].text = "Critical Damage : " + CharacterStat.criticalRate.ToString();
    }

    //일단은 체력/데미지/스킬데미지 만 상승
    void setUpstatDisplay()
    {
        upStatText[0].text = "HP : " + (CharacterStat.maxHp + UpgradeStat).ToString();
        upStatText[1].text = "Damage : " + (CharacterStat.atkDamage + UpgradeStat).ToString();
        upStatText[2].text = "Skill Damage : " + (CharacterStat.skillDamage + UpgradeStat).ToString();
        upStatText[3].text = "Critical Rate : " + (CharacterStat.criticalRate).ToString();
        upStatText[4].text = "Critical Damage : " + (CharacterStat.criticalRate).ToString();
    }

    public void statUpgrade()
    {
        if(Game_System.Gold > upgradeCost)
        {
            Game_System.Gold -= upgradeCost;
            upgradeCost += upgradeCost;

            CharacterStat.maxHp += UpgradeStat;
            CharacterStat.atkDamage += UpgradeStat;
            CharacterStat.skillDamage += UpgradeStat;
            setStatDisplay();
            setUpstatDisplay();
            goldText.text = upgradeCost.ToString();
        }
    }
}
