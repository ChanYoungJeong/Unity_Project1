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
    public void AddToInventory(Equipment item)
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i] == null)
            {
                Inventory[i] = item;
                AddToSlot(i, item);
                break;
            }
        }
    }

    //Add item into slot and change the image
    public void AddToSlot(int index, Equipment item)
    {
        slots[index].SetItem(item.name);
        slots[index].curItem = item;
    }

    private Sprite GetImage(string itemName)
    {
        Sprite image = Resources.Load<Sprite>("Image/Equipment/" + itemName);      
        return image;
    }


    public void EquipItem()
    {
        if (selectedItem != null)
        {
            if (!EM.Equipments.ContainsKey(selectedItem.type) && !curSlot.isEquiped)  //If item is not equiped;
            {
                EM.Equipments.Add(selectedItem.type, selectedItem);
                curSlot.ChangeToEquiped();
                EM.changeEquipImage(GetImage(selectedItem.name));
                EM.setPlayerStat(selectedItem);
                Debug.Log("is Equiped");
                Debug.Log(EM.Equipments[selectedItem.type].name);
            }
            else if (EM.Equipments.ContainsKey(selectedItem.type) && curSlot.isEquiped)        //Unequip item
            {
                EM.resetPlayerStat(EM.Equipments[selectedItem.type]);
                UnequipItem(selectedItem);
                curSlot.ChangeToUnequiped();
                Debug.Log("is UnEquiped");
                Debug.Log(EM.Equipments[selectedItem.type].name);
            }
            else if(EM.Equipments.ContainsKey(selectedItem.type) && !curSlot.isEquiped)       //Change Item
            {
                EM.resetPlayerStat(EM.Equipments[selectedItem.type]);
                EM.setPlayerStat(selectedItem);

                ResetEquipedSlot(selectedItem.type);
                curSlot.ChangeToEquiped();
                EM.Equipments[selectedItem.type] = selectedItem;
                EM.changeEquipImage(GetImage(selectedItem.name));
                Debug.Log("is Change Equipped");
                Debug.Log(EM.Equipments[selectedItem.type].name);
            }
            equipInfoUI.status.text = curSlot.itemStatus();
        }
        else
        {
            Debug.Log("There is no item selected");
        }
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
            equipInfoUI.ViewItem(GetImage(curSlot.curItem.name), curSlot.curItem, curSlot.itemStatus());
 
        }
        preSlot = curSlot;
    }

    public void ThrowItem()
    {
        if (!slots[selectedSlot].isEquiped && curSlot.curItem != null)
        {
            Inventory.RemoveAt(curSlot.slotNumber);
            curSlot.ResetSlot();
            AlignSlot(curSlot.slotNumber);
            if(curSlot.curItem == null)
            {
                curSlot.ChangeToDefaultColor();
            }
        }
        else
        {
            Debug.Log("This item is Equpiped");
        }
    }



    private void AlignSlot(int deletedSlot)
    {
        Equipment temp = null;
        while(deletedSlot + 1 < numSlots && slots[deletedSlot + 1].curItem != null)
        {
            temp = slots[deletedSlot + 1].curItem;
            slots[deletedSlot].curItem = temp;
            slots[deletedSlot].SetItem(temp.name);
            slots[deletedSlot + 1].ResetSlot();       
            deletedSlot++;
        }
    }

    private void ResetEquipedSlot(string type)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].curItem.type == type && slots[i].isEquiped)
            {
                slots[i].ChangeToUnequiped();
                return;
            }
        }
    }


}
