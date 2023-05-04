using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemManager : MonoBehaviour
{
    public Slot[] slots;
    public Transform slotHolder;

    public Slot specialSlot;

    private int RandomNum;
    private List<bool> NumberList = new List<bool>();
    private int[] ResetNumber;
    private ShopGetItem getItemManager;
    private void Awake()
    {
        getItemManager = GetComponent<ShopGetItem>();
        slots = slotHolder.GetComponentsInChildren<Slot>();
        GenerateSlot();
        RandomNum = Random.Range(0, ItemManager.loadObjects.Length);
        ResetNumber = new int[slots.Length];
    }

    private void Start()
    {
        getItemManager.ResetAllSlotColor();
        GenerateCheckList();
        GenerateItem();
        GenerateSpeicalItem();
    }

    //Array to Check if that slot is picked
    private void GenerateCheckList()
    {
        for(int i = 0; i < ItemManager.loadObjects.Length; i++)
        {
            NumberList.Add(true);
        }    
    }

    //Set Slot Number
    private void GenerateSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNumber = i;
        }
    }

    //Set Basic Item Lists (left Panel)
    public void GenerateItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            while(NumberList[RandomNum] == false)
            {
                RandomNum = Random.Range(0, ItemManager.loadObjects.Length);
            }
            NumberList[RandomNum] = false;
            slots[i].SetItem(ItemManager.loadObjects[RandomNum].name, ItemManager.loadObjects[RandomNum]);
            ResetNumber[i] = RandomNum;
        }
    }

    public void ReloadItem()
    {
        if (!getItemManager.doRot)
        {
            getItemManager.leftSlot = slots.Length;
            getItemManager.rotSpeed = 0.1f;
            getItemManager.ResetVisitedSlot();
            getItemManager.ResetAllSlotColor();
            for (int i = 0; i < slots.Length; i++)
            {
                NumberList[ResetNumber[i]] = true;
            }
            GenerateItem();
            GenerateSpeicalItem();
        }
    }

    //For Speical Items
    void GenerateSpeicalItem()
    {
        int rand = Random.Range(0, ItemManager.specialLoadObjects.Length);
        specialSlot.SetItem(ItemManager.specialLoadObjects[rand].name, ItemManager.specialLoadObjects[rand]);
    }
}
