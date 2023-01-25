using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menufalse : MonoBehaviour
{
    
    public GameObject inventoryui;
    public GameObject equipment;
    public GameObject shop;
    public GameObject heroui;
    public GameObject subchar;

    public GameObject ContropButtonUi;

    public GameObject mainmenubt;


    /*public bool Roguecount = false;
    public bool Magiccount = false;
    public bool Priestcount = false;
    public bool Archercount = false;
    public bool Alchemistcount = false;*/


    public GameObject RoguePanel;
    public GameObject MagicCasterPanel;
    public GameObject PriestPanel;
    public GameObject ArcherPanel;
    public GameObject AlchemistPanel;

    public void Start()
    {
        ContropButtonUi.SetActive(false);
        
        inventoryui.SetActive(false);
        equipment.SetActive(false);
        shop.SetActive(false);
        heroui.SetActive(false);
        subchar.SetActive(false);
        ContropButtonUi.SetActive(false);
    }
    public void Update()
    {

    }
    public void ShopOnoff()
    {
        if (shop.activeSelf == true)
        {
            //shop.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            subchar.SetActive(false);
            //shopbt.SetActive(false);
        }

        else if (shop.activeSelf == false)
        {
            shop.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            subchar.SetActive(false);
        }

    }
    public void EquipmentOnoff()
    {
        if (inventoryui.activeSelf == true)
        {
            //inventoryui.SetActive(false);
            //equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            subchar.SetActive(false);

            // eqibt.SetActive(false);
        }
        else if (inventoryui.activeSelf == false)
        {
            inventoryui.SetActive(true);
            equipment.SetActive(true);
            shop.SetActive(false);
            heroui.SetActive(false);
            subchar.SetActive(false);
        }
    }
    public void Herouionoff()
    {
        if (heroui.activeSelf == false)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);

            heroui.SetActive(true);
            subchar.SetActive(true);
        }
        else if (heroui.activeSelf == true)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);

            //heroui.SetActive(false);
            // gameobject5.SetActive(false);
            // herobt.SetActive(false);

        }
    }
    public void MainOnOffSetActive()
    {
        if (ContropButtonUi.activeSelf == true)
        {
            ContropButtonUi.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            subchar.SetActive(false);
        }
        else
        {
            ContropButtonUi.SetActive(true);
            equipment.SetActive(true);
            inventoryui.SetActive(true);
        }

    }
    public void ButtonAllOff()
    {
        ContropButtonUi.SetActive(false);
        inventoryui.SetActive(false);
        equipment.SetActive(false);
        shop.SetActive(false);
        heroui.SetActive(false);
        subchar.SetActive(false);
    }

    public void ClickStaticon()
    {
        /*if (gameobject5.activeSelf == false)
        {
            gameobject5.SetActive(true);
            heroui.SetActive(true);
            Debug.Log("oh"+Roguecount);
            RoguePanel.SetActive(Roguecount);
            MagicCasterPanel.SetActive(Magiccount);
            PriestPanel.SetActive(Priestcount);
            ArcherPanel.SetActive(Archercount);
            AlchemistPanel.SetActive(Alchemistcount);
        }
        else
        {
            gameobject5.SetActive(false);
            heroui.SetActive(false);
        }*/
    }

    public void ClickShopIcon()
    {
        inventoryui.SetActive(false);
        equipment.SetActive(false);
        heroui.SetActive(false);
        subchar.SetActive(false);
       
        if (shop.activeSelf == false)
        {
            ContropButtonUi.SetActive(true);
            shop.SetActive(true);

            
        }
        else if(shop.activeSelf == false&&ContropButtonUi.activeSelf==true)
        {
            shop.SetActive(true);
        }
        else
        {
            ContropButtonUi.SetActive(false);
            shop.SetActive(false);
        }
    }
}

    