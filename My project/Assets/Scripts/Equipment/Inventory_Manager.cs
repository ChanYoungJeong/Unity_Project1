using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory_Manager : MonoBehaviour
{
    public static List<Equipment> Inventory = new List<Equipment>();
    public static Equipment selectedItem;
    public static int selectedSlot;
    public Slot[] slots;
    public Slot curSlot;
    public Slot preSlot;
    int numSlots;
    public Transform slotHolder;
    public EquipmentManager EM;
    public Equipment_Gacha DBManager;
    public EquipInfo equipInfoUI;

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
            Inventory.Add(null);
        }
    }

    //Add item to inventory list and show in slot
    public void AddToInventory(Equipment item, Sprite img)
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i] == null)
            {
                Inventory[i] = item;
                AddToSlot(i, item, img);
                break;
            }
        }
    }

    //Add item into slot and change the image
    public void AddToSlot(int index, Equipment item, Sprite img)
    {
        slots[index].SetItem(item.name, img);
        slots[index].curItem = item;
    }

    private Sprite GetImage(string itemName)
    {
        Sprite image = Resources.Load<Sprite>("Image/Equipment/" + itemName);      
        return image;
    }

    public void SelectItem()
    {
        GameObject _slot = EventSystem.current.currentSelectedGameObject;
        curSlot = _slot.GetComponent<Slot>();

        if(curSlot.curItem != null)
        { 
            //Change the previous selected slot's color to default
            if(preSlot != null)
            {
                preSlot.ChangeToDefaultColor();
            }
            //Change the slected slot's color
            selectedItem = curSlot.curItem;
            curSlot.GetComponent<Image>().color = Color.red;
            //View Item info
            equipInfoUI.gameObject.SetActive(true);
            equipInfoUI.ViewItem(GetImage(curSlot.curItem.name), curSlot.curItem, curSlot.itemStatus());
            preSlot = curSlot;
        }     
    }

    private void AlignSlot(int deletedSlot)
    {
        Slot temp = null;
        while(deletedSlot + 1 < numSlots && slots[deletedSlot + 1].curItem != null)
        {
            temp = slots[deletedSlot + 1];
            slots[deletedSlot].curItem = temp.curItem;
            slots[deletedSlot].SetItem(temp.itemName, temp.itemImage);
            slots[deletedSlot + 1].ResetSlot();       
            deletedSlot++;
        }
    }


}
