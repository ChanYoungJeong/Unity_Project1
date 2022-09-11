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
           EM.Equipments.Add(selectedItem.type, selectedItem);
           EM.transform.Find(selectedItem.type).GetComponent<Image>().sprite = GetImage(selectedItem.name);
        }
    }
}
