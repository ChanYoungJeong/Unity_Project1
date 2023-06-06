using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGetItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activeRullet;

    public Transform slotHolder;
    public Slot[] slots;
    public ItemManager ItemMan;
    public Inventory_Manager Inven;
    public Slot specialSlot;
    public Button buyButton;

    Color defaultColor;
    float defaultColorAlpha;
    
    public float rotSpeed = 0.1f;
    int randomNum;
    bool[] PickedItem;
    public bool doRot = false;
    public int leftSlot;


    bool pickedSpecial;
    [SerializeField]
    float pickUpRate;

    private void Awake()
    {
        //activeRullet = true;
        defaultColorAlpha = 0.5f;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        defaultColor = slots[0].GetComponent<Image>().color;
        PickedItem = new bool[slots.Length];
        randomNum = Random.Range(0, slots.Length);
        leftSlot = slots.Length;
    }

    public void startRulet()
    {
        if (doRot == false)
        {
            if (leftSlot > 0)
                if(activeRullet)
                    StartCoroutine(GachaAnim());
                else
                    GetItem();
            else
            {
                DeactiveBuyButton();
                GetSpecialItem();
            }
        }
    }

    IEnumerator GachaAnim()
    {
        doRot = true;
        while (rotSpeed < 1)
        {
            setRandomNumber();

            //Spinning the rulet
            ChangeSlotColor(slots[randomNum], 1.0f);
            yield return new WaitForSeconds(rotSpeed);
            //Decrease the speed of rulet
            rotSpeed *= 1.2f;
            //While spinning, return the previous slot to default color
            ChangeSlotColor(slots[randomNum], defaultColorAlpha);          
        }

        if (rotSpeed > 1)
        {
            GetItem();
        }


        //When there are less slots left, initial speed becomes slower
        randomNum = Random.Range(0, slots.Length);
        float slope = ((float)(0.6 - 0.1) / (1 - slots.Length));
        float n = (float)0.6 - slope;
        rotSpeed = slope * leftSlot + n;

        doRot = false;
    }


    //투명도 조절
    void ChangeSlotColor(Slot index, float alpha)
    {
        Color col = index.transform.GetChild(0).GetComponent<Image>().color;
        col.a = alpha;
        index.transform.GetChild(0).GetComponent<Image>().color = col;
    }

    public void ResetAllSlotColor()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            ChangeSlotColor(slots[i], defaultColorAlpha);
        }
        ChangeSlotColor(specialSlot, defaultColorAlpha);
    }

    public void ResetVisitedSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            PickedItem[i] = false;
        }
        pickedSpecial = false;
    }

    void GetItem()
    {
        setRandomNumber();
        //Get Item
        if (!pickedSpecial && Random.Range(0f, 100f) < pickUpRate)
        {
            GetSpecialItem();
        }
        else
        {
            ChangeSlotColor(slots[randomNum], 1.0f);
            PickedItem[randomNum] = true;
            Equipment Item = ItemManager.ItemLists[slots[randomNum].itemName];
            Inven.AddToInventory(Item, slots[randomNum].itemImage);
            leftSlot--;
        }

        if (leftSlot == 0 && pickedSpecial)
        {
            DeactiveBuyButton();
        }
    }

    void GetSpecialItem()
    {
        pickedSpecial = true;
        ChangeSlotColor(specialSlot, 1.0f);
        Equipment Item = ItemManager.ItemLists[specialSlot.itemName];
        Inven.AddToInventory(Item, specialSlot.itemImage);
    }

    void DeactiveBuyButton()
    {
        buyButton.interactable = false;
        Color col = buyButton.GetComponent<Image>().color;
        col.a = 0.5f;
        buyButton.GetComponent<Image>().color = col;
    }

    public void ActiveBuyButton()
    {
        buyButton.interactable = true;
        Color col = buyButton.GetComponent<Image>().color;
        col.a = 1.0f;
        buyButton.GetComponent<Image>().color = col;
    }

    void setRandomNumber()
    {
        randomNum = Random.Range(0, slots.Length);
        //if Random Number is already picked
        while (PickedItem[randomNum] == true)
        {
            //reroll the number
            randomNum = Random.Range(0, slots.Length);
        }
    }
}
