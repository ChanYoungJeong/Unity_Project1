using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;
    public Slot[] slots;
    int numSlots;
    public Transform slotHolder;

    private void Awake()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventoryPanel.SetActive(activeInventory);
        numSlots = slots.Length;
        //Debug.Log(numSlots);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void SetItem(string itemName)
    {
        for (int i = 0;i < numSlots; i++)
        {
            if(!slots[i].hasItem)
            {
                slots[i].transform.GetChild(0).GetComponentInChildren<Image>().sprite = GetImage(itemName);
                slots[i].hasItem = true;
                break;
            }
        }
    }

    private Sprite GetImage(string itemName)
    {
        Sprite image = Resources.Load<Sprite>("Image/Equipment/" + itemName);
 
        return image;
    }
}
