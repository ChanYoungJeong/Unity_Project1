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
    bool checkClosed;

    private void Awake()
    {
        checkClosed = false;
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
            Debug.Log("1");
            DBMS.UpdateData(GetInfo.UserAccount, Game_System.Gold, Game_System.Stage,
                          PlayerUpgrade.atk_scoreButton, PlayerUpgrade.hp_scoreButton);
            Debug.Log("2");
            delayQuit();
            Debug.Log("3");
        }
    }

    void delayQuit()
    {
        int _i = 0;
        float eTime = 0;
        while (_i < 5)
        {
            eTime += Time.deltaTime;
            if(eTime > 1)
            {
                _i++;
                eTime = 0;
                Debug.Log("1sec passed : " + _i);
            }
        }
    }
}
