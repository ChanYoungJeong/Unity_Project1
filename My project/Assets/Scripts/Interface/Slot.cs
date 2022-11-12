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
    public Color defaultColor;
    public int slotNumber;
    public bool isEquiped;


    private void Awake()
    {
        defaultImage = transform.GetChild(0).GetComponent<Image>().sprite;
        defaultColor = GetComponent<Image>().color;
    }

    public Equipment ChcekItem()
    {
        if(hasItem && curItem != null)
        {
            return curItem;
        }
        else
        {
            return null;
            //Do nothing;
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
        transform.GetChild(0).GetComponent<Image>().sprite = defaultImage;   //Change Slot effect to un equiped
        curItem = null;                                                      //Reset Slot
        hasItem = false;
    }

    public void ChangeToEquiped()                   //Change Slot effect to Equiped
    {
        GetComponent<Image>().color = Color.green;
        isEquiped = true;
    }

    public void ChangeToUnequiped()
    {
        GetComponent<Image>().color = defaultColor;
        isEquiped = false;
    }

    public string itemStatus()
    {
        if(isEquiped)
        {
            return "Equiped";
        }
        else
        {
            return "UnEquiped";
        }
    }
}
