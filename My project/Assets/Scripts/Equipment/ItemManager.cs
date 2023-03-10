using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //public static Dictionary<string, Equipment> Equipments;
    public static Sprite[] loadObjects;


    private void Awake()
    {
        getItemList();
       
    }

    //Load Item Assets in resource file
    public void getItemList()
    {
        loadObjects = Resources.LoadAll<Sprite>("Image/Equipment/");
    }

    public void GenerateItem(string ItemName)
    {

    }


}
