using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_GameSystem : MonoBehaviour
{
    System_Info GetInfo;
    public Data_Base_Manager DBMS;
    private void Awake()
    {
        if (GameObject.Find("Loading_Information") == null)
        {
            Game_System.Stage = 1;
            Game_System.Gold = 12345678;
        }
        else
        {
            GetInfo = GameObject.Find("Loading_Information").GetComponent<System_Info>();
            Game_System.Stage = GetInfo.Load_Stage;
            Game_System.Gold = GetInfo.Load_Gold;
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
            DBMS.DatabaseInsert("Update System set Stage = " + Game_System.Stage
                                                         + ",Gold = " + Game_System.Gold
                                                         + " where UserID = \'" + GetInfo.UserAccount + "\'");
        }
    }
}
