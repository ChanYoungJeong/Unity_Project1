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


    public void ShopOnoff()
    {
        if (shop.activeSelf == true)
        {
            shop.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
            shopbt.SetActive(false);
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
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);

            eqibt.SetActive(false);
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

            heroui.SetActive(false);
            gameobject5.SetActive(false);
            herobt.SetActive(false);

        }
    }
    public void MainOnOffSetActive()
    {
        mainmenubt.SetActive(true);

        if (herobt.activeSelf == false)
        {
            
            herobt.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
        else
        {
            herobt.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }

        if (shopbt.activeSelf == false)
        {
            shopbt.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
        else
        {
            shopbt.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }

        if (eqibt.activeSelf == false)
        {
            eqibt.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
        else
        {
            eqibt.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            heroui.SetActive(false);
            gameobject5.SetActive(false);
        }
    }
}
