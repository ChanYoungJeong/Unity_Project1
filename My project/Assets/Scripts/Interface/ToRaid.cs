using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaid : MonoBehaviour
{
    public void SceneChangeRaid()
    {
        SceneManager.LoadScene("New Raid");
    }
    public void SceneChangePriject()
    {
        SceneManager.LoadScene("Project");
        Time.timeScale = 1;
    }
    public void SceneChangeTowerDefense()
    {
        SceneManager.LoadScene("TowerDefense");

    }
}
