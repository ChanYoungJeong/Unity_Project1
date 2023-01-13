using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignIn_Panel_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SignINPanel;

    public void OpenSignIN()
    {
        SignINPanel.SetActive(true);
    }

    public void CloseSignIn()
    {
        SignINPanel.SetActive(false);
    }
}
