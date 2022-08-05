using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Data;
using Mono.Data.Sqlite;

public class Data_Base_Manager : MonoBehaviour
{
    void DBCreate()
    {
        string filepath = string.Empty;     //File Path
        if (Application.platform == RuntimePlatform.Android) //If Platform is Android
        {
            filepath = Application.persistentDataPath + "/[filename].db"; //Set Path for Android

            if (!File.Exists(filepath)) //if there is no file
            {
                //Copy Files
                //Wait until file is complety copied (using UnityWebRequest)
                //If done copying, move files
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/[filename].db");
                unityWebRequest.downloadedBytes.ToString();
                while (!unityWebRequest.SendWebRequest().isDone) { }
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
            }
        }
        else
        {
            filepath = Application.dataPath + "/test.db";       //Set the path
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/test.db", filepath); //Copy the file due to path
            }
            Debug.Log($"{File.Exists(filepath)}" + "is done creating");
        }

    }


    public string GetDBFilePath()   //return the path due to platform
    {
        string str = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file" + Application.persistentDataPath + "/test.db";
        }
        else
        {
            str = "URI=file" + Application.dataPath + "/test.db";
        }        
        return str;
    }

    public void DataBaseRead(string query)
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();                                        //Open DB
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;                              //Write Query
        IDataReader dataReader = dbCommand.ExecuteReader();

        while(dataReader.Read())                    //Read Records
        {
            Debug.Log($"{dataReader.GetString(0)}");    //Read field 0
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
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = query;              //Write Query
        dbCommand.ExecuteNonQuery();                //Execute Query

        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
}
