using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Data;
using Mono.Data.Sqlite;

public class Equipment_Gacha : MonoBehaviour
{
    public Inventory_Manager invenManager;
    public inventoryUI invenUI;
    private void Awake()
    {
        DBCreate();
    }

    public void Weapon_Gacha()
    {

        if (Inventory_Manager.Inventory.Count < 18)
        {
            Get_Equipment("SELECT * FROM Weapon ORDER BY RANDOM() LIMIT 1");
            Debug.Log(Inventory_Manager.Inventory[Inventory_Manager.Inventory.Count - 1].name);
            invenUI.SetItem(Inventory_Manager.Inventory[Inventory_Manager.Inventory.Count - 1].name);
        }
        else
        {
            Debug.Log("Inventory is full");          
        } 
            
    }

    void DBCreate()
    {
        string filepath = string.Empty;     //File Path
        if (Application.platform == RuntimePlatform.Android) //If Platform is Android
        {
            filepath = Application.persistentDataPath + "/Equipment Data.db"; //Set Path for Android

            if (!File.Exists(filepath)) //if there is no file
            {
                //Copy Files
                //Wait until file is complety copied (using UnityWebRequest)
                //If done copying, move files
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/Equipment Data.db");
                unityWebRequest.downloadedBytes.ToString();
                while (!unityWebRequest.SendWebRequest().isDone) { }
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
            }
        }
        else
        {
            filepath = Application.dataPath + "/Equipment Data.db";       //Set the path
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/Equipment Data.db", filepath); //Copy the file due to path
            }
            //Debug.Log($"{File.Exists(filepath)} " + "is done creating");
        }

    }


    public string GetDBFilePath()   //return the path due to platform
    {
        string str = string.Empty;

        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file:" + Application.persistentDataPath + "/Equipment Data.db";
        }
        else
        {
            str = "URI=file:" + Application.dataPath + "/Equipment Data.db";
        }
        return str;
    }

    public void Get_Equipment(string query)
    {
        Equipment Item;
        int keyValue;        

        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();                                        //Open DB
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;                              //Write Query
        IDataReader dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())                    //Read Records and Insert into structure
        {
            Item = new Equipment(dataReader.GetInt32(0),  //Read field 0....
                                 dataReader.GetString(1),
                                 dataReader.GetString(2),
                                 dataReader.GetInt32(3),
                                 dataReader.GetInt32(4));
            keyValue = dataReader.GetInt32(0);

            Inventory_Manager.Inventory.Add(Item);      //Insert into Inventory
            
        }
        

        dataReader.Dispose();           //Close DB opposite order
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    public void DatabaseInsert(string query) //Useage : Modify, Insert, Delete
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();                        //Open DB
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;              //Write Query
        dbCommand.ExecuteNonQuery();                //Execute Query

        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
}

