using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public string itemCode;
    public string itemName;
    public string itemDescript;
    public Sprite itemImage;
    public int itemPrice;

    public string eventKey;

    public ItemData(string itemCode, string itemName, string itemDescript, int itemPrice, string eventKey)
    {
        this.itemCode = itemCode;
        this.itemName = itemName;
        this.itemDescript = itemDescript;
        this.itemImage = Resources.Load<Sprite>($"Sprites/Items/{itemCode}");
        this.itemPrice = itemPrice;
        this.eventKey = eventKey;
    }

    public void UseItem(params object[] p)
    {
        EventManager.SendEvent(eventKey, p);
    }
}