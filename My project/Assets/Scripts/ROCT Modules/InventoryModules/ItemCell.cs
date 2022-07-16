using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCell
{
    public ItemData data;
    public int itemCount;

    public ItemCell()
    {
        data = new ItemData("", "", "", 0, "");
        itemCount = 0;
    }

    public void SetCell(ItemCell other)
    {
        data = other.data;
        itemCount = other.itemCount;
    }
}