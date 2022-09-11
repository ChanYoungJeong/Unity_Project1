using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool hasItem = false;
    public Sprite itemImage;
    public Equipment curItem;

    public void SelectItem()
    {
        if(hasItem && curItem != null)
        {
            Inventory_Manager.selectedItem = curItem;
            Debug.Log(Inventory_Manager.selectedItem.name + " is Selected");
        }
        else
        {

        }
    }
}
