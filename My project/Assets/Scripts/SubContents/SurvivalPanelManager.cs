using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SurvivalPanelManager : MonoBehaviour
{
    string difficulty;
    Button[] asderList;
    Image[] asderSelect;

    public Transform asderListHolder;
    public Transform asderSelectHolder;

    private void Start()
    {
        asderList = asderListHolder.GetComponentsInChildren<Button>();
        asderSelect = asderSelectHolder.GetComponentsInChildren<Image>();

    }

    public void getDifficulty()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        difficulty = clickObject.GetComponentInChildren<Text>().text;       
    }

    public void selectAsder()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        SurvivalPanelAsderSlot asderSlot = clickObject.GetComponent<SurvivalPanelAsderSlot>();
        if (asderSlot.isSelected == false)
        {
            //자기 자신의 이미지도 들고와서 1번부터 시작, 이유는 모르겠음
            for (int i = 1; i < asderSelect.Length; i++)
            {
                if (asderSelect[i].sprite == null)
                {
                    asderSelect[i].sprite = clickObject.GetComponent<Image>().sprite;
                    asderSlot.isSelected = true;
                    break;
                }
            }
        }
        else
        {
            for (int i = 1; i < asderSelect.Length; i++)
            {
                if(asderSelect[i].sprite == clickObject.GetComponent<Image>().sprite)
                {
                    asderSelect[i].sprite = null;
                    asderSlot.isSelected = false;
                }
            }
        }
    }

    public void startSurvival()
    {
        SceneManager.LoadScene("SubContents 1");
    }
}
