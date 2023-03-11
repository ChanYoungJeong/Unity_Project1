using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool hasItem = false;
    public Sprite itemImage;
    public string itemName;
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

    public void SetItem(string _itemName)
    {
        transform.GetChild(0).GetComponentInChildren<Image>().sprite = GetImage(_itemName);
        itemName = _itemName;
    }

    private Sprite GetImage(string itemName)
    {
        Sprite image = Resources.Load<Sprite>("Image/Equipment/" + itemName);
        return image;
    }

    public void ResetSlot()                
    {
        ChangeToDefaultImage();                      //Change Slot effect to un equiped
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

    public void ChangeToDefaultImage()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = defaultImage;
    }

    public void ChangeToDefaultColor()
    {
        transform.GetComponent<Image>().color = defaultColor;
    }
}
