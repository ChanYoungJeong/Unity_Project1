using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    public static List<Equipment> Inventory = new List<Equipment>();
    public static Equipment selectedItem;
    public static int selectedSlot;
    public Slot[] slots;
    int numSlots;
    public Transform slotHolder;
    public EquipmentManager EM;
    public Equipment_Gacha DBManager;

    private void Awake()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        numSlots = slots.Length;
        GenerateSlot();
    }

    private void GenerateSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNumber = i;
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
        Debug.Log(Inventory[selectedSlot].name + "has removed");
        Inventory.RemoveAt(selectedSlot);
        slots[selectedSlot].ResetSlot();
        AlignSlot(selectedSlot);
        //DBManager.DatabaseInsert("DELETE * FROM INVENTORY WHERE CODE = " + selectedItem.code);
    }

    public void UnequipItem(Equipment item)
    {
        EM.Equipments.Remove(item.type);                        //Remove item from Dictionary
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

    private void AlignSlot(int deletedSlot)
    {
        Equipment temp = null;
        while(deletedSlot + 1 < numSlots && slots[deletedSlot + 1] != null && slots[deletedSlot + 1].hasItem)
        {
            temp = slots[deletedSlot + 1].curItem;
            slots[deletedSlot].curItem = temp;
            slots[deletedSlot].SetItem(temp.name);
            slots[deletedSlot + 1].ResetSlot();
            deletedSlot++;
        }
    }


}
