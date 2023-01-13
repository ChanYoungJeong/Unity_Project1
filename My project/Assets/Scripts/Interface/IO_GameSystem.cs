using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_GameSystem : MonoBehaviour
{
    [SerializeField]
    System_Info GetInfo;
    [SerializeField]
    Amazon_CognitoSync DBMS;
    public ButtonScript PlayerUpgrade;
    public GameObject QuitObject;
    public GameObject SubChars;
    public PlayerScript Player;
    public GameObject RoguePanel;
    public GameObject MagicCasterPanel;
    public GameObject PriestPanel;
    public GameObject ArcherPanel;
    public GameObject AlchemistPanel;


    private void Awake()
    {
        
        if (GameObject.Find("Loading_Information") == null)
        {
            Game_System.Stage = 1;
            Game_System.Gold = 12345678;
            PlayerUpgrade.atk_scoreButton = 0;
            PlayerUpgrade.hp_scoreButton = 0;
        }
        else
        {
            GetInfo = GameObject.Find("Loading_Information").GetComponent<System_Info>();
            DBMS = GameObject.Find("Server_Manager").GetComponent<Amazon_CognitoSync>();
            Debug.Log(GetInfo.Load_Stage);
            Game_System.Stage = GetInfo.Load_Stage;
            Game_System.Gold = GetInfo.Load_Gold;
            PlayerUpgrade.atk_scoreButton = GetInfo.Player_Attack_Rate;
            PlayerUpgrade.hp_scoreButton = GetInfo.Player_Hp_Rate;
            Player.lv = GetInfo.Player_LV;
            Player.playerNowExp = GetInfo.Player_EXP;

            SubChars.transform.GetChild(0).gameObject.SetActive(GetInfo.Rogue_Active);
            RoguePanel.SetActive(GetInfo.Rogue_Active);
            SubChars.transform.GetChild(1).gameObject.SetActive(GetInfo.MagicCaster_Active);
            MagicCasterPanel.SetActive(GetInfo.MagicCaster_Active);
            SubChars.transform.GetChild(2).gameObject.SetActive(GetInfo.Priest_Active);
            PriestPanel.SetActive(GetInfo.Priest_Active);
            SubChars.transform.GetChild(3).gameObject.SetActive(GetInfo.Archer_Active);
            ArcherPanel.SetActive(GetInfo.Archer_Active);
            SubChars.transform.GetChild(4).gameObject.SetActive(GetInfo.Alchemist_Active);
            AlchemistPanel.SetActive(GetInfo.Alchemist_Active);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("up") && DBMS != null)
        {
            DBMS.UpdateData(GetInfo.UserAccount, Game_System.Gold, Game_System.Stage,
                PlayerUpgrade.atk_scoreButton, PlayerUpgrade.hp_scoreButton, Player.lv, Player.playerNowExp,
                SubChars.transform.GetChild(0).gameObject.activeSelf,
                SubChars.transform.GetChild(1).gameObject.activeSelf,
                SubChars.transform.GetChild(2).gameObject.activeSelf,
                SubChars.transform.GetChild(3).gameObject.activeSelf,
                SubChars.transform.GetChild(4).gameObject.activeSelf);
        }
    }


    private void OnApplicationQuit()
    {
        if (GameObject.Find("Loading_Information") == null)
        {
            //Do nothing
        }
        else
        {
            
        }
    }


}
