using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShadow : MonoBehaviour
{
    /// <summary>
    /// �����ִ°� ���δ� AsderCall�� �ű����
    /// </summary>
    //����
    //public Button[] SubButton;
    public Transform ButtonHolder;
    [SerializeField]
    private Button[] SubButtons;
    //����
    HeroSummon SubCount;
    
    private void Awake()
    {
        //��� �����Ҵ��� �ƴѵ� �� FInd�� ���°��� ����� �����
        SubCount = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        SubButtons = ButtonHolder.GetComponentsInChildren<Button>(); //����
    }

    private void Update()
    {
        //�̷��� ������ �ý겥
        if (SubCount.AsderCount[0] > 0)
        {
            OnAsderButton();
        }
        else
        {
            OffAsderButton();
        }
    }

    //�̰� �� asderCall�� �ű����
    public void OffAsderButton()
    {
        for(int i=0; i< SubButtons.Length; i++)
        {
            SubButtons[i].interactable = false;
        }
    }

    public void OnAsderButton()
    {
        //�̵����� ������ �����
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
