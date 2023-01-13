using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

[InitializeOnLoad]
public class QuitGame : MonoBehaviour
{
    public Action quitEvent;
    Amazon_CognitoSync DBMS;
    System_Info GetInfo;
    public bool isApplicationQuit;
    public ButtonScript PlayerUpgrade;
    public GameObject gameSystem;

    private void Awake()
    {
        Debug.Log("Quit System ON");
        //GetInfo = GameObject.Find("Loading_Information").GetComponent<System_Info>();
        if (GameObject.Find("Server_Manager"))
        {
            DBMS = GameObject.Find("Server_Manager").GetComponent<Amazon_CognitoSync>();
        }
        isApplicationQuit = false;

        InitializeApplicationQuit();
    }

    private void InitializeApplicationQuit()
    {
        Debug.Log("QuitProcess " + isApplicationQuit);

        //EditorApplication.wantsToQuit += ApplicationQuit;
        Application.wantsToQuit += ApplicationQuit;
        Debug.Log(isApplicationQuit);
    }

    private void Update()
    {
        //isApplicationQuit = DBMS.isUpdated;
    }

    private bool ApplicationQuit()
    {
        quitEvent += () =>
        {
            Debug.Log("trying to quit");
        };

        return isApplicationQuit;
    }
}
