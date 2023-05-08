using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaid : MonoBehaviour
{
    public void SceneChangeRaid()
    {
        SceneManager.LoadScene("Re_Raid");
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
}
