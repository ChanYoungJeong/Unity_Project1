using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISizeController : MonoBehaviour
{
    

    public GameObject ContentUI;
    public GameObject SkillMenuUI;
    public GameObject SubContentsUI;
    public GameObject SpeedControllerUI;
    public GameObject MenuUI;
    public GameObject SoundSettingUI;
    public GameObject ShopUI;
    public GameObject InventoryUI;
    public GameObject SubCharUI;
    public GameObject HeroStatUI;



    void Awake()
    {
        ContentUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(-878, -482, 0);
        ContentUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);  
        
        SkillMenuUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(960, 540, 0);
        SkillMenuUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100); 

        SubContentsUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(960, 109, 0);
        SubContentsUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100); 

        SpeedControllerUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(960, 64, 0);
        SpeedControllerUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);    
        
        MenuUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(-48, -560, 0);
        MenuUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100); 
        
        SoundSettingUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        SoundSettingUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);

        ShopUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(-74, 78, 0);
        ShopUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

        InventoryUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 60, 0);
        InventoryUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

        SubCharUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 60, 0);
        SubCharUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

        HeroStatUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 60, 0);
        HeroStatUI.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
