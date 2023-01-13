using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubCharSetting : MonoBehaviour
{
    public PlayerScript Player_Object;
    public int player_LEVEL;
    int Roguecount=0;
    int Magiccount = 0;
    int Pirstcount = 0;
    int Archercount = 0;
    int Alchemistcount = 0;

    public GameObject SettingPanel;
    public GameObject RoguePanel;
    public GameObject MagicCasterPanel;
    public GameObject PriestPanel;
    public GameObject ArcherPanel;
    public GameObject AlchemistPanel;

    public GameObject Rogue;
    public GameObject MagicCaster;
    public GameObject Priest;
    public GameObject Archer;
    public GameObject Alchemist;


    private void Start()
    {
        SettingPanel.SetActive(false);
        RoguePanel.SetActive(false);
        MagicCasterPanel.SetActive(false);
        PriestPanel.SetActive(false);
        ArcherPanel.SetActive(false);
        AlchemistPanel.SetActive(false);
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
                Rogue.SetActive(true);
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
        player_LEVEL = Player_Object.lv;

        if (player_LEVEL == 4 && Game_System.Gold >= 500)
        {
            if (Magiccount == 0)
            {
                Game_System.Gold -= 500;
                MagicCasterPanel.SetActive(true);
                Magiccount++;
            }
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
        player_LEVEL = Player_Object.lv;

        if (player_LEVEL == 10 && Game_System.Gold >= 2000)
        {
            if (Pirstcount == 0)
            {
                Game_System.Gold -= 2000;
                PriestPanel.SetActive(true);
                Pirstcount++;
            }
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


    //Archer
    public void ArcherStatWindowPanel()
    {
        player_LEVEL = Player_Object.lv;

        if (player_LEVEL == 2 && Game_System.Gold >= 10)
        {
            if (Archercount == 0)
            {
                Game_System.Gold -= 10;
                ArcherPanel.SetActive(true);
                Archercount++;
            }
        }
    }

    public void ArcherSetActive()
    {
        if (Archer.activeSelf == false)
        {
            Archer.SetActive(true);
        }
        else
        {
            Archer.SetActive(false);
        }
    }
    public void BackArcherSetting()
    {
        if (ArcherPanel.activeSelf == true)
        {
            ArcherPanel.SetActive(false);
            SettingPanel.SetActive(true);
        }
    }



    //Alchemist
    public void AlchemistStatWindowPanel()
    {
        player_LEVEL = Player_Object.lv;

        if (player_LEVEL == 2 && Game_System.Gold >= 10)
        {
            if (Alchemistcount == 0)
            {
                Game_System.Gold -= 10;
                AlchemistPanel.SetActive(true);
                Alchemistcount++;
            }
        }
    }

    public void AlchemistSetActive()
    {
        if (Alchemist.activeSelf == false)
        {
            Alchemist.SetActive(true);
        }
        else
        {
            Alchemist.SetActive(false);
        }
    }
    public void BackAlchemistSetting()
    {
        if (AlchemistPanel.activeSelf == true)
        {
            AlchemistPanel.SetActive(false);
            SettingPanel.SetActive(true);
        }
    }

}
