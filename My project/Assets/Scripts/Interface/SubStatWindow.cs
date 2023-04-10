using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubStatWindow : MonoBehaviour
{
    public Stat Player_Object;
    public Text lv;
    public Text attack;
    public Text skillDamage;
    public int Gold;
    public int UpgreadeAtkStat;
    //new write
    public int BuyGold;
    public int NeedLevel;
    public GameObject SubchPanel;
    bool  SubchCount= false;
    public SubChar_Combat_manager subStat;

    private void Start()
    {
        SubchPanel.SetActive(false);
    }

    public void SubCharBuy() //동그라미 버튼
    {
        if (Player_Object.player_lv >= NeedLevel && Game_System.Gold >= BuyGold)
        {
            if (SubchCount == false)
            {
                Game_System.Gold -= BuyGold;
                SubchPanel.SetActive(true);
                SubchCount=true;


                skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
                attack.text = "attack " + subStat.attackDmg.ToString();
                lv.text = "Lv " + subStat.lv.ToString();
            }
        }
        
    }

    public void SubCharAttackUpgrade()
    {
        int Level;

        if (Game_System.Gold >= Gold)
        {
            Game_System.Gold -= Gold;
            subStat.lv++;
            subStat.skillDamage += UpgreadeAtkStat;
            subStat.attackDmg += UpgreadeAtkStat;

            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
            attack.text = "attack " + subStat.attackDmg.ToString();
            lv.text = "Lv " + subStat.lv.ToString();
        }
    }

    // public void SubcharSetActive()
    // {
    //     if(SubCharName.activeSelf == false)
    //     {
    //         SubCharName.SetActive(true);
    //         SubCharName.GetComponentInChildren<SubBasicAttack>().isCoolTime = true;
    //         SubCharName.GetComponentInChildren<SubSkillAttack>().isCoolTime = true;
    //     }
    //     else
    //     {
    //         SubCharName.SetActive(false);
    //     }
    // }

}
