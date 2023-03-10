using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGetItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Slot[] slots;
    public Transform slotHolder;
    public ItemManager ItemMan;
    public Inventory_Manager Inven;

    Color defaultColor;
    
    public float rotSpeed = 0.1f;
    int randomNum;
    bool[] PickedItem;
    public bool doRot = false;
    public int leftSlot;


    private void Awake()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        defaultColor = slots[0].GetComponent<Image>().color;
        PickedItem = new bool[slots.Length];
        randomNum = Random.Range(0, slots.Length);
        leftSlot = slots.Length;
    }

    public void startRulet()
    {
        if (doRot == false && leftSlot > 0)
        {
            StartCoroutine(GachaAnim());
        }
    }

    IEnumerator GachaAnim()
    {
        doRot = true;
        while (rotSpeed < 1)
        {
            randomNum = Random.Range(0, slots.Length);
            while(PickedItem[randomNum] == true)
            {
                randomNum = Random.Range(0, slots.Length);
            }

            //Spinning the rulet
            ChangeSlotColor(randomNum, Color.black);
            yield return new WaitForSeconds(rotSpeed);
            //Decrease the speed of rulet
            rotSpeed *= 1.2f;
            if (rotSpeed > 1)
            {
                //Got Item
                ChangeSlotColor(randomNum, Color.red);
                PickedItem[randomNum] = true;
                Equipment Item = ItemMan.GenerateItem(slots[randomNum].itemName);
                Inven.AddToInventory(Item);
                break;
            }
            else
            {
                //While spinning, return the previous slot to default color
                ChangeSlotColor(randomNum, defaultColor);
            }
        }
        doRot = false;

        //When there are less slots left, initial speed becomes slower
        randomNum = Random.Range(0, slots.Length);
        float slope = ((float)(0.6 - 0.1) / (1 - slots.Length));
        float n = (float)0.6 - slope;
        leftSlot--;
        rotSpeed = slope * leftSlot + n;
    }


    void ChangeSlotColor(int index, Color color)
    {
        slots[index].GetComponent<Image>().color = color;
    }

    public void ResetAllSlotColor()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            ChangeSlotColor(i, defaultColor);
        }
    }

    void ItemGet(int slotNum)
    {
        //getItemIndex = slotNum;
        ItemMan.GenerateItem(slots[slotNum].itemName);
    }

    public void ResetVisitedSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            PickedItem[i] = false;
        }
    }
}
