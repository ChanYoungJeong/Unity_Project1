using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShadow : MonoBehaviour
{
    /// <summary>
    /// 여기있는거 전부다 AsderCall로 옮길거임
    /// </summary>
    //찬영
    //public Button[] SubButton;
    public Transform ButtonHolder;
    [SerializeField]
    private Button[] SubButtons;
    //찬영
    HeroSummon SubCount;
    
    private void Awake()
    {
        SubCount = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        SubButtons = ButtonHolder.GetComponentsInChildren<Button>(); //찬영
    }

    private void Update()
    {
        //이렇게 만들라고 씹쎄꺄
        if (SubCount.AsderCount[0] > 0)
        {
            OnAsderButton();
        }
        else
        {
            OffAsderButton();
        }
    }

    //이거 다 asderCall에 옮길거임
    public void OffAsderButton()
    {
        for(int i=0; i< SubButtons.Length; i++)
        {
            SubButtons[i].interactable = false;
        }
    }

    public void OnAsderButton()
    {
        //이따구로 만들지 말라고
        /*
        for(int i=0; i< SubButtons.Length;i++)
        {
            if (SubCount.AsderCount[i] > 0)
            {
                SubButtons[i].interactable = true;
            }
            else 
            {
                SubButtons[i].interactable = false;
            }
        }
        */
        for(int i = 0; i < SubButtons.Length; i++)
        {
            SubButtons[i].interactable = true;
        }
    }
}
