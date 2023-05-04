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
    //�����Ƽ� �ӽ÷� ����
    //������ index�� �����ϳ� ���Ŀ� ���� �ּ� ó���س����� ó�� ���ε��� �����ص� ����
    [Tooltip("ü��/������/��ų������/ũ��Ƽ����/ũ��Ƽ�� ������ ������� ���ƾ��Ѵ�")]
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

    //�ϴ��� ü��/������/��ų������ �� ���
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
