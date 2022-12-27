using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubCharSetting : MonoBehaviour
{
    public PlayerScript Player_Object;
    public int player_LEVEL;
    int Roguecount=0;

    public GameObject SettingPanel;
    public GameObject RoguePanel;
    public GameObject MagicCasterPanel;
    public GameObject PriestPanel;

    public GameObject Rogue;
    public GameObject MagicCaster;
    public GameObject Priest;


    private void Start()
    {
        SettingPanel.SetActive(false);
        RoguePanel.SetActive(false);
        MagicCasterPanel.SetActive(false);
        PriestPanel.SetActive(false);
    }

    public void SettingPanelSetActive()
    {
            if (SettingPanel.activeSelf == false)
            {
                SettingPanel.SetActive(true);
            }
            else
            {
                SettingPanel.SetActive(false);
            }
    }

    //Rogue

    public void RogueStatWindowPanel()
    {
        
        player_LEVEL = Player_Object.lv;

        if (player_LEVEL == 2 && Game_System.Gold >= 100)
        {
            if (Roguecount == 0)
            {
                Game_System.Gold -= 100;
                Debug.Log("sibal" +Game_System.Gold);
                RoguePanel.SetActive(true);
                Roguecount++;
            }
        }
        
    }

    public void RogueSetActive()
    {
        if(Rogue.activeSelf == false)
        {
            Rogue.SetActive(true);
            Rogue.GetComponentInChildren<SubBasicAttack>().isCoolTime = true;
            Rogue.GetComponentInChildren<SubSkillAttack>().isCoolTime = true;
        }
        else
        {
            Rogue.SetActive(false);
        }
    }

    public void BackRogueSetting()
    {
        if(RoguePanel.activeSelf == true)
        {
            RoguePanel.SetActive(false);
            SettingPanel.SetActive(true);
        }
    }


    //MagicCaster

    public void MagicCasterStatWindowPanel()
    {
        if (MagicCasterPanel.activeSelf == false)
        {
            //SettingPanel.SetActive(false);
            MagicCasterPanel.SetActive(true);
        }
        else
        {
            MagicCasterPanel.SetActive(false);
        }
    }
    public void MagicCasterSetActive()
    {
        if (MagicCaster.activeSelf == false)
        {
            MagicCaster.SetActive(true);
        }
        else
        {
            MagicCaster.SetActive(false);
        }
    }

    public void BackMagicCasterSetting()
    {
        if (MagicCasterPanel.activeSelf == true)
        {
            MagicCasterPanel.SetActive(false);
            SettingPanel.SetActive(true);
        }
    }


    //Priest
    public void PriestStatWindowPanel()
    {
        if (PriestPanel.activeSelf == false)
        {
            //SettingPanel.SetActive(false);
            PriestPanel.SetActive(true);
        }
        else
        {
            PriestPanel.SetActive(false);
        }
    }

    public void PriestSetActive()
    {
        if (Priest.activeSelf == false)
        {
            Priest.SetActive(true);
        }
        else
        {
            Priest.SetActive(false);
        }
    }
    public void BackPriestSetting()
    {
        if (PriestPanel.activeSelf == true)
        {
            PriestPanel.SetActive(false);
            SettingPanel.SetActive(true);
        }
    }


}
