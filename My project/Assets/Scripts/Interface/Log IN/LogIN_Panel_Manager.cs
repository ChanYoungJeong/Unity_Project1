using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIN_Panel_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SignINPanel;
    public void ActiveSignIn()
    {
        SignINPanel.SetActive(true);
    }

    public void CloseSIgnIn()
    {
        SignINPanel.SetActive(false);
    }
}
