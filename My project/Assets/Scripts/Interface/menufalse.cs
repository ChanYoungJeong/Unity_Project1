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
    public GameObject gameobject5;

    public GameObject shopbt;
    public GameObject eqibt;
    public GameObject herobt;

    public GameObject mainmenubt;
    public GameObject Btnalloff;

    
    public void ShopOnoff()
    {
        if (shop.activeSelf == true)
        {
            //shop.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
            //shopbt.SetActive(false);
        }

        else if (shop.activeSelf == false)
        {
            shop.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
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
            gameobject5.SetActive(false);

           // eqibt.SetActive(false);
        }
        else if (inventoryui.activeSelf == false)
        {
            inventoryui.SetActive(true);
            equipment.SetActive(true);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
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
            gameobject5.SetActive(true);
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
        equipment.SetActive(true);
        inventoryui.SetActive(true);

        if (eqibt.activeSelf == true)
        {
            eqibt.SetActive(false);
            shopbt.SetActive(false);
            herobt.SetActive(false);
            Btnalloff.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
        else
        {
            eqibt.SetActive(true);
            shopbt.SetActive(true);
            herobt.SetActive(true);
            Btnalloff.SetActive(true);
        }
        
    }
    public void ButtonAllOff()
    {
        Btnalloff.SetActive(false);
        herobt.SetActive(false);
        eqibt.SetActive(false);
        shopbt.SetActive(false);
        inventoryui.SetActive(false);
        equipment.SetActive(false);
        shop.SetActive(false);
        heroui.SetActive(false);
        gameobject5.SetActive(false);
    }

    public void ClickStaticon()
    {
        if (heroui.activeSelf==false) {
            shopbt.SetActive(true);
            herobt.SetActive(true);
            eqibt.SetActive(true);
            Btnalloff.SetActive(true);

            heroui.SetActive(true);
            gameobject5.SetActive(true);
            shop.SetActive(false);
        }
        else
        {
            shopbt.SetActive(false);
            herobt.SetActive(false);
            eqibt.SetActive(false);
            Btnalloff.SetActive(false);

            heroui.SetActive(false);
            gameobject5.SetActive(false);

        }
    }

    public void ClickShopIcon()
    {
        if (shop.activeSelf == false)
        {
            shopbt.SetActive(true);
            herobt.SetActive(true);
            eqibt.SetActive(true);
            Btnalloff.SetActive(true);

            shop.SetActive(true);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
        else
        {
            shopbt.SetActive(false);
            herobt.SetActive(false);
            eqibt.SetActive(false);
            Btnalloff.SetActive(false);

            shop.SetActive(false);
        }
    }
}