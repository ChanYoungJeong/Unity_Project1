using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menufalse : MonoBehaviour
{
    public GameObject inventoryui;
    public GameObject equipment;
    public GameObject shop;
    public GameObject gameObject4;

    
    public void ShopOnoff()
    {
        if (shop.activeSelf == true)
        {
            shop.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
        }
        
        else if(shop.activeSelf == false)
        {
            shop.SetActive(true);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            
        }
        
    }
    public void EquipmentOnoff()
    {
        if (inventoryui.activeSelf == true && equipment.activeSelf == true)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
        }
        else if (equipment.activeSelf == false && inventoryui.activeSelf == false)
        {
            inventoryui.SetActive(true);
            equipment.SetActive(true);
            shop.SetActive(false);
        }
    }

}
