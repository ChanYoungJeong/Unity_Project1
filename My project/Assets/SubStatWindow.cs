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

    private int MagicCasterAttackGold = 1500;
    private int MagicCasterAtkSpeedGold = 1500;

    private int PriestAttackGold = 2000;
    private int PriestAtkSpeedGold = 2000;

    SubChar_Combat_manager subStat;

    private void Start()
    {
        this.name.Contains("Rogue");

        this.name.Contains("MagicCaster");

        this.name.Contains("Priest");

        if (this.name.Contains("Rogue"))
        {
            subStat = GameObject.Find("Rogue").GetComponent<SubChar_Combat_manager>();


            lv.text = "Lv " + subStat.lv.ToString();
            attack.text = "Attack " + subStat.attackDmg.ToString();
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();
        }
        else if (this.name.Contains("MagicCaster"))
        {
            subStat = GameObject.Find("MagicCaster").GetComponent<SubChar_Combat_manager>();

           
            lv.text = "Lv " + subStat.lv.ToString();
            attack.text = "Attack " + subStat.attackDmg.ToString();
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();
        }
        else if (this.name.Contains("Priest"))
        {
            subStat = GameObject.Find("Priest").GetComponent<SubChar_Combat_manager>();

           
            lv.text = "LV " + subStat.lv.ToString();
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

    public void MagicCasterAttackUpgrade()
    {
        if (Game_System.Gold >= MagicCasterAttackGold)
        {
            Game_System.Gold -= MagicCasterAttackGold;

            subStat.attackDmg += 3;
            attack.text = "attack " + subStat.attackDmg.ToString();

        }
    }

    public void MagicCasterAtkSpeedUpgrade()
    {
        if (Game_System.Gold >= MagicCasterAtkSpeedGold)
        {
            Game_System.Gold -= MagicCasterAtkSpeedGold;

            subStat.atkSpeed += 1;
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();

        }
    }

    public void PriestAttackUpgrade()
    {

        if (Game_System.Gold >= PriestAttackGold)
        {
            Game_System.Gold -= PriestAttackGold;

            subStat.attackDmg += 2;
            attack.text = "attack " + subStat.attackDmg.ToString();

        }
    }

    public void PriestAtkSpeedUpgrade()
    {
        if (Game_System.Gold >= PriestAtkSpeedGold)
        {
            Game_System.Gold -= PriestAtkSpeedGold;

            subStat.atkSpeed += 0.5f;
            atkSpeed.text = "AtkSpeed " + subStat.atkSpeed.ToString();

        }
    }
}
