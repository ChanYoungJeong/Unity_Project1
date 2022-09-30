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
    private void Awake()
    {
        DBCreate();
    }

    private void OnApplicationQuit()
    {
        DatabaseInsert("DELETE FROM Inventory");
    }

    public void Weapon_Gacha()
    {
        float rand = Random.Range(0, 100);
        if (Inventory_Manager.Inventory.Count < 18)
        {
            Debug.Log(Inventory_Manager.Inventory.Count);
            Get_Equipment("SELECT * FROM Weapon WHERE GRADE = \"" + GetByProbability(rand) + "\" ORDER BY RANDOM() LIMIT 1");

            DatabaseInsert("INSERT INTO Inventory VALUES(\'"
                            + Inventory_Manager.Inventory[Inventory_Manager.Inventory.Count - 1].name + "\',\'"
                            + Inventory_Manager.Inventory[Inventory_Manager.Inventory.Count - 1].type + "\',"
                            + (Inventory_Manager.Inventory.Count - 1) + ","
                            + "\'UNEQUIPED\')");
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

        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();                                        //Open DB
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;                              //Write Query
        IDataReader dataReader = dbCommand.ExecuteReader();

        if(dataReader.Read())                    //Read Records and Insert into structure
        {
            Item = new Equipment(dataReader.GetInt32(0),   //Read field 0....                               
                                 dataReader.GetString(1),  
                                 dataReader.GetString(2),
                                 dataReader.GetInt32(3),                                 
                                 dataReader.GetInt32(4),
                                 dataReader.GetString(5)
                                 );

            Inventory_Manager.Inventory.Add(Item);      //Insert into Inventory
            invenManager.slots[Inventory_Manager.Inventory.Count - 1].curItem = Item;
            invenManager.slots[Inventory_Manager.Inventory.Count - 1].SetItem(Item.name);           
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

    string GetByProbability(float value)
    {
        if (value <= 70)
        {
            return "Normal";
        }
        else if (value > 70 && value <= 90)
        {
            return "Rare";
        }
        else if (value > 90)
        {
            return "Epic";
        }
        else
        {
            Debug.Log("Something Wrong");
            return null;
        }
    }
}

