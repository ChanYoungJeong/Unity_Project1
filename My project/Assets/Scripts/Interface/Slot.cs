using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool hasItem = false;
    public Sprite itemImage;
    public Equipment curItem;
    public bool isEqupied;
    public Sprite defaultImage;
    public GameObject selectedSlot;


    private void Awake()
    {
        defaultImage = GetComponentInChildren<Image>().sprite;
    }

    public void SelectItem()
    {
        if(hasItem && curItem != null)
        {
            Inventory_Manager.selectedItem = curItem;
            Debug.Log(Inventory_Manager.selectedItem.name + " is Selected");
            selectedSlot = this.gameObject;
           // Debug.Log(selectedSlot.name);
        }
        else
        {

        }
    }
}
