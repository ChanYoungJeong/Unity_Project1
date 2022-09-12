using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<string, Equipment> Equipments;
    public Image[] eSlots;
    int numSlots;
    public Transform eSlotHolder;


    void Awake()
    {
        eSlots = eSlotHolder.GetComponentsInChildren<Image>();
        numSlots = eSlots.Length;
        Equipments = new Dictionary<string, Equipment>();
       
        //Equipments["Weapon"].stat1;

    }



}
