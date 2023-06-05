using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaid : MonoBehaviour
{
    public bool boss1 = false;
    public bool boss2 = false;


    public void SceneChangeRaid()
    {
        if (boss1)
        {
            boss1 = false;
            SceneManager.LoadScene("Re_Raid");
        }
        else if (boss2)
        {
            SceneManager.LoadScene("Re_Raid2");
        }
    }
    public void SceneChangeProject()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Project");
        Time.timeScale = 1;
    }
    public void SceneChangeSurvival()
    {
        SceneManager.LoadScene("SubContents 1");
    }

    public void SelectBoss1_Raid()
    {
        boss2 = false;
        boss1 = true;
    }

    public void SelectBoss2_Raid()
    {
        boss1 = false;
        boss2 = true;
    }
}
