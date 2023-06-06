using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubCharStatUpgrade : MonoBehaviour
{
    public Stat[] CharacterStat;
    public Text CharName;
    public Image CharImage;
    public int index;
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
    public Text[] statText;
    public Transform upStatTextHolder;
    public Text[] upStatText;
    public int upgradeCost;
    public Text goldText;
    public int UpgradeStat;
    //new write
    public int BuyGold;
    public int NeedLevel;


    public void Awake()
    {
        statText = statTextHolder.GetComponentsInChildren<Text>();
        upStatText = upStatTextHolder.GetComponentsInChildren<Text>();
        setUpgradeCost();
        setStatDisplay();
        setUpstatDisplay();
    }

    void setStatDisplay()
    {
        CharName.text = CharacterStat[index].gameObject.name;
        CharImage.sprite = Resources.Load<Sprite>("Image/SubChar/" + CharacterStat[index].gameObject.name);
        statText[0].text = "HP : " + CharacterStat[index].maxHp.ToString();
        statText[1].text = "Damage : " + CharacterStat[index].atkDamage.ToString();
        statText[2].text = "Skill Damage : " + CharacterStat[index].skillDamage.ToString();
        statText[3].text = "Critical Rate : " + CharacterStat[index].criticalRate.ToString();
        statText[4].text = "Critical Damage : " + CharacterStat[index].criticalRate.ToString();
    }

    //일단은 데미지/스킬데미지 만 상승
    void setUpstatDisplay()
    {
        upStatText[0].text = "HP : " + (CharacterStat[index].maxHp).ToString();
        upStatText[1].text = "Damage : " + (CharacterStat[index].atkDamage + UpgradeStat).ToString();
        upStatText[2].text = "Skill Damage : " + (CharacterStat[index].skillDamage + UpgradeStat).ToString();
        upStatText[3].text = "Critical Rate : " + (CharacterStat[index].criticalRate).ToString();
        upStatText[4].text = "Critical Damage : " + (CharacterStat[index].criticalRate).ToString();
    }


    public void statUpgrade()
    {
        if (Game_System.Gold > upgradeCost)
        {
            Game_System.Gold -= upgradeCost;
            CharacterStat[index].lv++;
            CharacterStat[index].atkDamage += UpgradeStat;
            CharacterStat[index].skillDamage += UpgradeStat;
            setStatDisplay();
            setUpstatDisplay();
            setUpgradeCost();
        }
    }

    void setUpgradeCost()
    {
        upgradeCost = CharacterStat[index].lv * 10;
        goldText.text = upgradeCost.ToString();
    }

    public void GoToNextChar()
    {
        if(index == CharacterStat.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        setStatDisplay();
        setUpstatDisplay();
        setUpgradeCost();
    }

    public void GoToPrevChar()
    {
        if (index == 0)
        {
            index = CharacterStat.Length - 1;
        }
        else
        {
            index--;
        }
        setStatDisplay();
        setUpstatDisplay();
        setUpgradeCost();
    }
}
