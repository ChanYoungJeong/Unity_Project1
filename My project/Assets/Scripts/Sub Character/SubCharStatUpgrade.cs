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
    //�����Ƽ� �ӽ÷� ����
    //������ index�� �����ϳ� ���Ŀ� ���� �ּ� ó���س����� ó�� ���ε��� �����ص� ����
    [Tooltip("ü��/������/��ų������/ũ��Ƽ����/ũ��Ƽ�� ������ ������� ���ƾ��Ѵ�")]
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

    //�ϴ��� ������/��ų������ �� ���
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
