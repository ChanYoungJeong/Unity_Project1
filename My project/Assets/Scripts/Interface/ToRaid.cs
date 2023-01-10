using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaid : MonoBehaviour
{
    public void SceneChangeRaid()
    {
        SceneManager.LoadScene("Raid");
    }
    public void SceneChangePriject()
    {
        SceneManager.LoadScene("Project");
    }
    public void SceneChangeTowerDefense()
    {
        SceneManager.LoadScene("TowerDefense");

    }
}
