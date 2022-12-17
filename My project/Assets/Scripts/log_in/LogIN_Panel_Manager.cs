using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogIN_Panel_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Data_Base_Manager DBMS;
    public GameObject LoadInfo;
    System_Info SystemInfo;

    public InputField InputID;
    public InputField InputPassword;


    //Table : Users  {UserID(Text), Password(Text)}
    //Table : System {UserID(Text/FK), Stage(INTEGER), GOLD(INTEGER)}
    public void LogIN()
    {
        if (InputPassword.text == DBMS.GetString("Select Password FROM Users WHERE UserID  = \'" + InputID.text + "\'"))
        {
            CheckAccountInfo();
            SceneChange();
        }
        else
        {
            Debug.Log("ID or Password is wrong");
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Project");
        DontDestroyOnLoad(LoadInfo);
    }

    void CheckAccountInfo()
    {
        string ID = InputID.text;
        int s_Stage = DBMS.GetInt("Select Stage From System Where UserID  = \'" + InputID.text + "\'");
        int s_Gold = DBMS.GetInt("Select Gold From System Where UserID  = \'" + InputID.text + "\'");
        int s_PlayerAttack = DBMS.GetInt("Select PlayerAttackRate From System Where UserID  = \'" + InputID.text + "\'");
        int s_PlayerHp = DBMS.GetInt("Select PlayerHpRate From System Where UserID  = \'" + InputID.text + "\'");
        SetLoading(ID, s_Stage, s_Gold, s_PlayerAttack, s_PlayerHp);
        
    }

    void SetLoading(string ID, int Stage, int Gold, int PlayerAttack, int PlayerHp)
    {
        SystemInfo = LoadInfo.GetComponent<System_Info>();
        SystemInfo.UserAccount = ID;
        SystemInfo.Load_Stage = Stage;
        SystemInfo.Load_Gold = Gold;
        SystemInfo.Player_Attack_Rate = PlayerAttack;
        SystemInfo.Player_Hp_Rate = PlayerHp;
    }
}
