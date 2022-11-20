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
        }
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

    public void selectItem()
    {
        GameObject _slot = EventSystem.current.currentSelectedGameObject;
        curSlot = _slot.GetComponent<Slot>();
        Debug.Log("Slot" + curSlot.name + "is selected");

        if(curSlot.curItem != null)
        {
            selectedItem = curSlot.curItem;
            Debug.Log(selectedItem.type);
            equipInfoUI.gameObject.SetActive(true);
            if (selectedItem.type == "Weapon")
            {
                equipInfoUI.ViewItem(GetImage(selectedItem.name), selectedItem.name, selectedItem.grade, 
                                curSlot.itemStatus(),"Attack", "Critical Rate", selectedItem.stat1.ToString(),
                                     selectedItem.stat2.ToString(), selectedItem.upgrade.ToString());
            }
        }
        else
        {
            if (equipInfoUI.gameObject.activeSelf)
            {
                equipInfoUI.gameObject.SetActive(false);
            }
        }
    }

    public void DeleteItem()
    {
        if (!slots[selectedSlot].isEquiped)
        {
            Debug.Log(Inventory[selectedSlot].name + "has removed");
            Inventory.RemoveAt(selectedSlot);
            slots[selectedSlot].ResetSlot();
            AlignSlot(selectedSlot);
            //DBManager.DatabaseInsert("DELETE * FROM INVENTORY WHERE CODE = " + selectedItem.code);
        }
        else
        {
            Debug.Log("This item is Equpiped");
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
