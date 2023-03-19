using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubStatWindow : MonoBehaviour
{
    public Text lv;
    public Text attack;
    public Text skillDamage;

    private int RogueAttackGold = 1000;
    private int RogueskillDamageGold = 1000;

    private int MagicCasterAttackGold = 1500;
    private int MagicCasterskillDamageGold = 1500;

    private int PriestAttackGold = 2000;
    private int PriestskillDamageGold = 2000;

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
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
        }

        else if (this.name.Contains("MagicCaster"))
        {
            subStat = GameObject.Find("MagicCaster").GetComponent<SubChar_Combat_manager>();

           
            lv.text = "Lv " + subStat.lv.ToString();
            attack.text = "Attack " + subStat.attackDmg.ToString();
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
        }

        else if (this.name.Contains("Priest"))
        {
            subStat = GameObject.Find("Priest").GetComponent<SubChar_Combat_manager>();

           
            lv.text = "LV " + subStat.lv.ToString();
            attack.text = "Attack " + subStat.attackDmg.ToString();
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
        }
    }

    /*public void RogueAttackUpgrade()
    {

        if (Game_System.Gold >= RogueAttackGold)
        {
            Game_System.Gold -= RogueAttackGold;

            subStat.attackDmg += 2;
            attack.text = "attack " + subStat.attackDmg.ToString();

        }
    }*/

    public void RogueLevelUpgrade()
    {
        int Level;

        if (Game_System.Gold >= RogueskillDamageGold)
        {
            Game_System.Gold -= RogueskillDamageGold;

            Level = subStat.lv;
            subStat.lv ++;
           
            if (subStat.lv != Level)
            {
                Debug.Log("½Ã¹ß");
                subStat.skillDamage += 2;
                subStat.attackDmg += 2;
            }
            //subStat.skillDamage += 2;
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();
            attack.text = "attack " + subStat.attackDmg.ToString();
            lv.text = "Lv " + subStat.lv.ToString();

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

    public void MagicCasterskillDamageUpgrade()
    {
        if (Game_System.Gold >= MagicCasterskillDamageGold)
        {
            Game_System.Gold -= MagicCasterskillDamageGold;

            subStat.skillDamage += 1;
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();

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

    public void PriestskillDamageUpgrade()
    {
        if (Game_System.Gold >= PriestskillDamageGold)
        {
            Game_System.Gold -= PriestskillDamageGold;

            subStat.skillDamage += 0.5f;
            skillDamage.text = "skillDamage " + subStat.skillDamage.ToString();

        }
    }
}
