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
    public GameObject gameobject5;

    public GameObject shopbt;
    public GameObject eqibt;
    public GameObject herobt;

    public Button mainmenubt;

    
    
    public void ShopOnoff()
    {
        if (shop.activeSelf == true)
        {
            shop.SetActive(false);
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shopbt.SetActive(false);
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
        
        if (equipment.activeSelf == false && inventoryui.activeSelf == false)
        {
            inventoryui.SetActive(true);
            equipment.SetActive(true);
            shop.SetActive(false);
        }
        else if(inventoryui.activeSelf == true && equipment.activeSelf == true)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            eqibt.SetActive(false);
            
        }
    }

    public void Herouionoff()
    {
        if (gameObject4.activeSelf==false)
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);

            gameObject4.SetActive(true);
            gameobject5.SetActive(true);
        }
        else if (gameObject4.activeSelf == true )
        {
            inventoryui.SetActive(false);
            equipment.SetActive(false);
            shop.SetActive(false);
            
            gameObject4.SetActive(false);
            gameobject5.SetActive(false);
            herobt.SetActive(false);

        }

    }

}
