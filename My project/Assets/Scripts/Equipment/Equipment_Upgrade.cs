using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment_Upgrade : MonoBehaviour
{

    Equipment targetItem;
    public EquipInfo eqiupInfo;
    int maxRate;
    int probability;
    void Start()
    {
        maxRate = 10;
    }


    public void UpgradeItem()
    {
        targetItem = Inventory_Manager.selectedItem;
        float val = getRandomInt();
        if (val < getProbability(targetItem.upgrade))
        {
            Inventory_Manager.selectedItem.upgrade += 1;
            Debug.Log("Upgrade Sucess!!/Current Rate : " + targetItem.upgrade);
            upgradeItem(Inventory_Manager.selectedItem);
            targetItem = Inventory_Manager.selectedItem;
            eqiupInfo.changeStatView(targetItem);
        }
        else if(getProbability(targetItem.upgrade) == 0)
        {
            Debug.Log("This item is already Max updgrae");
        }
        else
        {
            Debug.Log("Upgrade Failed/You've got : " + val);
        }
        
    }

    private int getRandomInt()
    {
        return Random.Range(0, 100);
    }

    private int getProbability(int currentRate)
    {
        if (currentRate <= 3)
        {
            return 100;
        }
        else if (currentRate > 3 && currentRate <= 6)
        {
            return 70;
        }
        else if (currentRate > 6 && currentRate <= 8)
        {
            return 30;
        }
        else if (currentRate > 8 && currentRate <= 9)
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }

    private void upgradeItem(Equipment Item)
    {
        int upgardeVal1 = (Item.upgrade / 2) + 1;
        int upgradeVal2 = (Item.upgrade / 2) + 1;
        Item.stat1 += upgardeVal1;
        Item.stat2 += upgradeVal2;
    }
}
