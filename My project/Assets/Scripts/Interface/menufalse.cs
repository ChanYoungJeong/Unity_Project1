using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menufalse : MonoBehaviour
{
    public GameObject inventoryui;
    public GameObject equipment;
    public GameObject shop;
    public GameObject heroui;
    public GameObject mainch;

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
            mainch.SetActive(false);
            shopbt.SetActive(false);
        }
        
        else if(shop.activeSelf == false)
        {
            shop.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            heroui.SetActive(false);
            mainch.SetActive(false);
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
            mainch.SetActive(false);

            eqibt.SetActive(false);
        }
        else if (inventoryui.activeSelf == false)
        {
            inventoryui.SetActive(true);
            equipment.SetActive(true);
            shop.SetActive(false);
            heroui.SetActive(false);
            mainch.SetActive(false);
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
            mainch.SetActive(true);
        }
        else if (heroui.activeSelf == true)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);

            heroui.SetActive(false);
            mainch.SetActive(false);
            herobt.SetActive(false);

        }
    }
    public void MainOnOffSetActive()
    {
        //mainmenubt.SetActive(!mainmenubt.active);
        if(mainmenubt.activeSelf == false)
        {

            Debug.LogError("±èº´¿ì");
            mainmenubt.SetActive(true);
            if (herobt.activeSelf == false)
            {
               
                heroui.SetActive(true);
            }
            if (shopbt.activeSelf == false)
            {
                shop.SetActive(true);
            }
            if (inventoryui.activeSelf == false)
            {
                eqibt.SetActive(true);
            }
        }
        
        
    }
}
