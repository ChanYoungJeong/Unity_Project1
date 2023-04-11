using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //public static Dictionary<string, Equipment> Equipments;
    public static Sprite[] loadObjects;
    public static Dictionary<string, Equipment> ItemLists;

    private void Awake()
    {
        ItemLists = new Dictionary<string, Equipment>();
        getItemList();
        generateItems();
    }

    //Load Item Assets in resource file
    public void getItemList()
    {
        loadObjects = Resources.LoadAll<Sprite>("Image/Equipment/");
    }

    private void generateItems()
    {     
        for(int i = 0; i < loadObjects.Length; i++)
        {
            string name = loadObjects[i].name;
            ItemLists.Add(name, getItem(name));
        }
    }

    public Equipment getItem(string ItemName)
    {
        int random = Random.Range(1, 10);
        Equipment item = new Equipment(1, ItemName, "Normal", random, random, "Weapon");
        return item;
    }
}
