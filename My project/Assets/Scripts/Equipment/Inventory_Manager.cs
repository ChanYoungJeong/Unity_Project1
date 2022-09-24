using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    public static List<Equipment> Inventory = new List<Equipment>();
    public static Equipment selectedItem;
    public Slot[] slots;
    int numSlots;
    public Transform slotHolder;
    public EquipmentManager EM;
    public Equipment_Gacha DBManager;

    private void Awake()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        numSlots = slots.Length;
    }

    public void SetItem(string itemName)
    {
        for (int i = 0; i < numSlots; i++)
        {
            if (!slots[i].hasItem)
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

    public void EquipItem()
    {
        if(selectedItem != null)
        {
            if (!EM.Equipments.ContainsKey(selectedItem.type))
            {
                EM.Equipments.Add(selectedItem.type, selectedItem);
                changeEquipImage();
            }
            else if(EM.Equipments[selectedItem.type].code == selectedItem.code)
            {
                UnequipItem(selectedItem);
            }
            else
            {
                EM.Equipments[selectedItem.type] = selectedItem;
                changeEquipImage();
            }    
        }
        else
        {
            Debug.Log("There is no item selected");
        }
    }

    public void DeleteItem()
    {
        Inventory.Remove(selectedItem);
        ResetImage(selectedItem);
        //DBManager.DatabaseInsert("DELETE * FROM INVENTORY WHERE CODE = " + selectedItem.code);
    }

    public void UnequipItem(Equipment item)
    {
        EM.Equipments.Remove(item.type);                        //Remove item from Dictionary
        Debug.Log("Here");
        for (int i = 0; i < EM.eSlots.Length; i++)              //Change image of Equpiment to default
        {
            if (EM.eSlots[i].name == selectedItem.type)
            {
                EM.eSlots[i].sprite = null;
            }
        }
    }

    private void changeEquipImage()
    {
        for (int i = 0; i < EM.eSlots.Length; i++)
        {
            if (EM.eSlots[i].name == selectedItem.type)
                EM.eSlots[i].sprite = GetImage(selectedItem.name);
        }
    }

    private void ResetImage(Equipment item)
    {
        Debug.Log(slots[0].selectedSlot.name);
        Debug.Log(slots[0].selectedSlot.GetComponentInChildren<Image>().sprite);
        slots[0].selectedSlot.transform.GetChild(0).GetComponent<Image>().sprite = slots[0].defaultImage;
    }


}
