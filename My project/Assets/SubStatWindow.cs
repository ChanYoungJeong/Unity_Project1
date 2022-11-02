using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubStatWindow : MonoBehaviour
{
    public Text lv;
    public Text attack;
    public Text atkSpeed;

    private int RogueAttackGold = 1000;
    private int RogueAtkSpeedGold = 1000;

    SubChar_Combat_manager subStat;

    private void Start()
    {

        if (this.name.Contains("Rogue"))
        {
            subStat = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>();


            lv.text = "Lv " + subStat.lv.ToString();
            attack.text = "Attack " + subStat.attackDmg.ToString();
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();
        }

    }

    public void RogueAttackUpgrade()
    {

        if (Game_System.Gold >= RogueAttackGold)
        {
            Game_System.Gold -= RogueAttackGold;

            subStat.attackDmg += 2;
            attack.text = "attack " + subStat.attackDmg.ToString();

        }
    }

    public void RogueAtkSpeedUpgrade()
    {
        if (Game_System.Gold >= RogueAtkSpeedGold)
        {
            Game_System.Gold -= RogueAtkSpeedGold;

            subStat.atkSpeed += 2;
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();

        }
    }
}
