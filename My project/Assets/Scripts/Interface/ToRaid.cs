using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaid : MonoBehaviour
{
public void SceneChange()
    {
        SceneManager.LoadScene("Raid");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Project");
    }
}
