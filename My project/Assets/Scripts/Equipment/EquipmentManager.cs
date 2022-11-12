using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<string, Equipment> Equipments; //<type, Equipment>
    public Image[] eSlots;
    int numSlots;
    public Transform eSlotHolder;
    public PlayerScript player;


    void Awake()
    {
        eSlots = eSlotHolder.GetComponentsInChildren<Image>();
        numSlots = eSlots.Length;
        Equipments = new Dictionary<string, Equipment>();
       
        //Equipments["Weapon"].stat1;

    }

    public void changeEquipImage(Sprite itemImage)
    {
        for (int i = 0; i < eSlots.Length; i++)
        {
            if (eSlots[i].name == Inventory_Manager.selectedItem.type)
                eSlots[i].sprite = itemImage;
        }
    }

    public void setPlayerStat(Equipment item)
    {
        if(item.type == "Weapon")
        {
            player.atkDmg += item.stat1;
            player.criticalDamage += item.stat2;
        }
    }

    public void resetPlayerStat(Equipment item)
    {
        if (item.type == "Weapon")
        {
            player.atkDmg -= item.stat1;
            player.criticalDamage -= item.stat2;
        }
    }

}
