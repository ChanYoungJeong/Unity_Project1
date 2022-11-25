using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SignIn_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    bool ID_Check;

    public Data_Base_Manager DBMS;
    public InputField UserID;
    public InputField Password;
    string InputID;
    string GetID;

    //Table : Users (UserID(Text), Password(Text)

    public void CheckUserID()
    {
        InputID = UserID.text;

        GetID = DBMS.CheckID("Select UserID FROM Users where UserID = \'" + InputID + "\'");
        if(InputID == GetID)
        {
            Debug.Log("User ID already exists");
        }
        else
        {
            Debug.Log("You can use ID : " + InputID);
            ID_Check = true;
        }
    }

    public void CreateAccount()
    {
        Debug.Log(InputID + ", " + Password.text);

        if (ID_Check)
        {
            DBMS.DatabaseInsert("INSERT INTO Users VALUES(\'"
                                + InputID + "\',\'"
                                + Password.text + "\')");
            Debug.Log("Account has created sucessfully");
        }
        else
        {
            Debug.Log("Something goes wrong");
        }
    }

}
