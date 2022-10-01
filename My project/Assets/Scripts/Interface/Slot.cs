using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool hasItem = false;
    public Sprite itemImage;
    public Equipment curItem;
    public Sprite defaultImage;
    public int slotNumber;


    private void Awake()
    {
        defaultImage = transform.GetChild(0).GetComponent<Image>().sprite;
    }

    public void SelectItem()
    {
        if(hasItem && curItem != null)
        {
            Inventory_Manager.selectedItem = curItem;
            Inventory_Manager.selectedSlot = slotNumber;
            Debug.Log(Inventory_Manager.selectedItem.name + " is Selected");
        }
        else
        {

        }
    }

    public void SetItem(string itemName)
    {
        if (!hasItem)
        {
            transform.GetChild(0).GetComponentInChildren<Image>().sprite = GetImage(itemName);
            hasItem = true;
        }
    }

    private Sprite GetImage(string itemName)
    {
        Sprite image = Resources.Load<Sprite>("Image/Equipment/" + itemName);
        return image;
    }

    public void ResetSlot()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = defaultImage;
        curItem = null;
        hasItem = false;
    }

}
