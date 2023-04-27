using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShadow : MonoBehaviour
{
    public Button[] SubButton;
    HeroSummon SubCount;
    
    private void Awake()
    {
        SubCount = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        OffAsderButton();
    }
    private void Update()
    {
        OnAsderButton();
    }
    public void OffAsderButton()
    {
        for(int i=0; i<SubButton.Length; i++)
        {
            SubButton[i].interactable = false;
        }
    }

    public void OnAsderButton()
    {
        for(int i=0; i<SubButton.Length;i++)
        {
            if (SubCount.AsderCount[i] > 0)
            {
                SubButton[i].interactable = true;
            }
            else 
            {
                SubButton[i].interactable = false;
            }
        }
    }
}
