using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject ItemInfoUI;
    bool activeInventory = false;

    private void Awake()
    {
        //inventoryPanel.SetActive(activeInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            if(!activeInventory)
            {
                ItemInfoUI.SetActive(false);
            }
            
        }
    }


}
