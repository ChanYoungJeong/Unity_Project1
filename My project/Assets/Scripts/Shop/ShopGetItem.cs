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
    float defaultColorAlpha;
    
    public float rotSpeed = 0.1f;
    int randomNum;
    bool[] PickedItem;
    public bool doRot = false;
    public int leftSlot;


    private void Awake()
    {
        defaultColorAlpha = 0.5f;
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
            ChangeSlotColor(randomNum, 1.0f);
            yield return new WaitForSeconds(rotSpeed);
            //Decrease the speed of rulet
            rotSpeed *= 1.2f;
            if (rotSpeed > 1)
            {
                //Got Item
                ChangeSlotColor(randomNum, 1.0f);
                PickedItem[randomNum] = true;
                Equipment Item = ItemManager.ItemLists[slots[randomNum].itemName];
                Inven.AddToInventory(Item);
                break;
            }
            else
            {
                //While spinning, return the previous slot to default color
                ChangeSlotColor(randomNum, defaultColorAlpha);
            }
        }
        

        //When there are less slots left, initial speed becomes slower
        randomNum = Random.Range(0, slots.Length);
        float slope = ((float)(0.6 - 0.1) / (1 - slots.Length));
        float n = (float)0.6 - slope;
        leftSlot--;
        rotSpeed = slope * leftSlot + n;

        doRot = false;
    }


    //투명도 조절
    void ChangeSlotColor(int index, float alpha)
    {
        Color col = slots[index].transform.GetChild(0).GetComponent<Image>().color;
        col.a = alpha;
        slots[index].transform.GetChild(0).GetComponent<Image>().color = col;
    }

    public void ResetAllSlotColor()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            ChangeSlotColor(i, defaultColorAlpha);
        }
    }

    public void ResetVisitedSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            PickedItem[i] = false;
        }
    }
}
