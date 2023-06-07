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

    public Slot curSlot;
    public Slot preSlot;
    int numSlots;

    public Slot[] slots;
    public Transform slotHolder;

    public Slot[] equipSlots;

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
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNumber = i;
            Inventory.Add(null);
        }

        for(int i = 0; i< equipSlots.Length; i++)
        {
            equipSlots[i].slotNumber = i;

        }
    }

    //Add item to inventory list and show in slot
    public void AddToInventory(Equipment item, Sprite img)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i] == null)
            {
                Inventory[i] = item;
                AddToSlot(i, item, img, item.type);
                break;
            }
        }
    }

    //Add item into slot and change the image
    public void AddToSlot(int index, Equipment item, Sprite img, string type)
    {
        slots[index].SetItem(item.name, img, type);
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

        if (curSlot.curItem != null)
        {
            //Change the previous selected slot's color to default
            if (preSlot != null)
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
        while (deletedSlot < numSlots && slots[deletedSlot + 1].curItem != null)
        {
            temp = slots[deletedSlot + 1];
            slots[deletedSlot].curItem = temp.curItem;
            slots[deletedSlot].SetItem(temp.itemName, temp.itemImage, temp.type);
            slots[deletedSlot + 1].ResetSlot();
            deletedSlot++;
        }
    }

    public void DeleteItem()
    {
        if (curSlot != null)
        {
            int num = curSlot.slotNumber;
            equipInfoUI.gameObject.SetActive(false);
            slots[num].ResetSlot();
            Inventory[num] = null;
        }
    }

    public void EquipmentChange()
    {

        if (curSlot != null)
        {
            int num = curSlot.slotNumber;

            for (int i = 0; i < equipSlots.Length; i++)
            {
                if (slots[num].curItem.type == "Socket" && equipSlots[i].type == "Socket")
                {
                    Debug.Log("0");

                    //Socket
                    if (equipSlots[i].curItem == null)
                    {
                        Debug.Log("1");
                        equipSlots[i].curItem = slots[num].curItem;
                        equipSlots[i].SetItem(slots[num].itemName, slots[num].itemImage, slots[num].type);
                        slots[num].ResetSlot();
                        Inventory[num] = null;
                    }
                    else
                    {
                        Debug.Log("4");
                    }

                }
                else if(equipSlots[i].type == slots[num].curItem.type && slots[num].curItem.type != "Socket")
                {
                    Debug.Log("-0");

                    if (equipSlots[i].curItem == null)
                    {
                        Debug.Log("3");

                        equipSlots[i].curItem = slots[num].curItem;
                        equipSlots[i].SetItem(slots[num].itemName, slots[num].itemImage, slots[num].type);
                        slots[num].ResetSlot();
                        Inventory[num] = null;
                    }
                    else
                    {
                        Debug.Log("2");

                        Slot temp = new Slot();
                        Debug.Log(equipSlots[i].itemImage);

                        //temp = equipSlots[i];
                        temp.curItem = equipSlots[i].curItem;
                        temp.itemImage = equipSlots[i].itemImage;
                        temp.itemName = equipSlots[i].itemName;

                        //3¹ø²¨ µû¿È
                        equipSlots[i].curItem = slots[num].curItem;
                        equipSlots[i].SetItem(slots[num].itemName, slots[num].itemImage, slots[num].type);
                        slots[num].ResetSlot(); // ¿©±â±îÁö 3¹ø

                        //slots[num] = temp;
                        slots[num].curItem = temp.curItem;
                        slots[num].SetItem(temp.itemName, temp.itemImage, temp.type);
                    }
                }
            }

        }
    }
}
