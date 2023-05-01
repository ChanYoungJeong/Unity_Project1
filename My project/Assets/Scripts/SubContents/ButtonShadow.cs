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
    HeroSummon heroSummon;

    private void Awake()
    {
        //��� �����Ҵ��� �ƴѵ� �� FInd�� ���°��� ����� ����� // �ذ�
        heroSummon = GetComponent<HeroSummon>();
        SubButtons = ButtonHolder.GetComponentsInChildren<Button>(); //����
    }

    private void Update()
    {
        //�̷��� ������ �ý겥
        if (heroSummon.AsderCount[0] > 0)
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
        for(int i = 0; i < SubButtons.Length; i++)
        {
            SubButtons[i].interactable = true;
        }
    }
}
