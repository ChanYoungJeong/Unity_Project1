using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //public static Dictionary<string, Equipment> Equipments;
    public static Sprite[] loadObjects;

    public static Sprite[] nomal_Armor;
    public static Sprite[] nomal_Belt;
    public static Sprite[] nomal_Boots;
    public static Sprite[] nomal_Helmet;
    public static Sprite[] nomal_Socket;
    public static Sprite[] nomal_Weapon;



    public static Sprite[] specialLoadObjects;

    public static Sprite[] special_Armor;
    public static Sprite[] special_Belt;
    public static Sprite[] special_Boots;
    public static Sprite[] special_Helmet;
    public static Sprite[] special_Socket;
    public static Sprite[] special_Weapon;

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

        loadObjects = Resources.LoadAll<Sprite>("Image/Equipment/Normal");

        nomal_Armor = Resources.LoadAll<Sprite>("Image/Equipment/Normal/Armor");
        nomal_Belt= Resources.LoadAll<Sprite>("Image/Equipment/Normal/Belt");
        nomal_Boots= Resources.LoadAll<Sprite>("Image/Equipment/Normal/Boots");
        nomal_Helmet= Resources.LoadAll<Sprite>("Image/Equipment/Normal/Helmet");
        nomal_Socket= Resources.LoadAll<Sprite>("Image/Equipment/Normal/Socket");
        nomal_Weapon = Resources.LoadAll<Sprite>("Image/Equipment/Normal/Weapon");


        specialLoadObjects = Resources.LoadAll<Sprite>("Image/Equipment/Special");

        special_Armor = Resources.LoadAll<Sprite>("Image/Equipment/Special/Armor");
        special_Belt= Resources.LoadAll<Sprite>("Image/Equipment/Special/Belt");
        special_Boots= Resources.LoadAll<Sprite>("Image/Equipment/Special/Boots");
        special_Helmet= Resources.LoadAll<Sprite>("Image/Equipment/Special/Helmet");
        special_Socket= Resources.LoadAll<Sprite>("Image/Equipment/Special/Socket");
        special_Weapon= Resources.LoadAll<Sprite>("Image/Equipment/Special/Weapon");

    }

    private void generateItems()
    {     
        //Nomal

        for(int i = 0; i < nomal_Armor.Length; i++)
        {
            string name = nomal_Armor[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Armor"));
        }

        for (int i = 0; i < nomal_Belt.Length; i++)
        {
            string name = nomal_Belt[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Belt"));
        }

        for (int i = 0; i < nomal_Boots.Length; i++)
        {
            string name = nomal_Boots[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Boots"));
        }

        for (int i = 0; i < nomal_Helmet.Length; i++)
        {
            string name = nomal_Helmet[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Helmet"));
        }

        for (int i = 0; i < nomal_Socket.Length; i++)
        {
            string name = nomal_Socket[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Socket"));
        }

        for (int i = 0; i < nomal_Weapon.Length; i++)
        {
            string name = nomal_Weapon[i].name;
            ItemLists.Add(name, getItem(name, "Normal", "Weapon"));
        }

        //Special

        for (int j = 0; j < special_Armor.Length; j++)
        {
            string name = special_Armor[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Armor"));
        }

        for (int j = 0; j < special_Belt.Length; j++)
        {
            string name = special_Belt[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Belt"));
        }

        for (int j = 0; j < special_Boots.Length; j++)
        {
            string name = special_Boots[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Boots"));
        }

        for (int j = 0; j < special_Helmet.Length; j++)
        {
            string name = special_Helmet[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Helmet"));
        }

        for (int j = 0; j < special_Socket.Length; j++)
        {
            string name = special_Socket[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Socket"));
        }

        for (int j = 0; j < special_Weapon.Length; j++)
        {
            string name = special_Weapon[j].name;
            ItemLists.Add(name, getItem(name, "Special", "Weapon"));
        }
    }

    public Equipment getItem(string ItemName, string Rate, string type)
    {
        int random = Random.Range(1, 10);
        Equipment item = new Equipment(1, ItemName, Rate , random, random, type);
        return item;
    }
}
