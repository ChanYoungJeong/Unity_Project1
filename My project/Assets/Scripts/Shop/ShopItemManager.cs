using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemManager : MonoBehaviour
{
    public Slot[] slots;
    public Transform slotHolder;
    private int RandomNum;
    private List<bool> NumberList = new List<bool>();
    private int[] ResetNumber;
    private ShopGetItem getItemManager;
    private void Awake()
    {
        getItemManager = GetComponent<ShopGetItem>();
        slots = slotHolder.GetComponentsInChildren<Slot>();
        GenerateSlot();
        RandomNum = Random.Range(0, slots.Length);
        ResetNumber = new int[slots.Length];
    }

    private void Start()
    {
        GenerateGachaList();
        GenerateItem();
    }

    private void GenerateGachaList()
    {
        for(int i = 0; i < ItemManager.loadObjects.Length; i++)
        {
            NumberList.Add(true);
        }
        
    }

    private void GenerateSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNumber = i;
        }
    }

    public void GenerateItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            while(NumberList[RandomNum] == false)
            {
                RandomNum = Random.Range(0, slots.Length);
            }
            NumberList[RandomNum] = false;
            //NumberList.RemoveAt(RandomNum);
            slots[i].transform.GetChild(0).GetComponentInChildren<Image>().sprite = ItemManager.loadObjects[RandomNum];
            slots[i].itemName = ItemManager.loadObjects[RandomNum].name;
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
        }
    }

}
