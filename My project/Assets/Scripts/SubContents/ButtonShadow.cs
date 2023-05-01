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
    HeroSummon heroSummon;

    private void Awake()
    {
        //얘는 동적할당이 아닌데 왜 FInd를 쓰는거임 끌어다 써야지 // 해결
        heroSummon = GetComponent<HeroSummon>();
        SubButtons = ButtonHolder.GetComponentsInChildren<Button>(); //찬영
    }

    private void Update()
    {
        //이렇게 만들라고 씹쎄꺄
        if (heroSummon.AsderCount[0] > 0)
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
        for(int i = 0; i < SubButtons.Length; i++)
        {
            SubButtons[i].interactable = true;
        }
    }
}
