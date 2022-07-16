using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private static List<ItemData> data = new List<ItemData>();
    public static void AddItem(ItemData item) => data.Add(item);
    public static ItemData GetItem(string itemCode) => data.Find(e => e.itemCode == itemCode);
}
