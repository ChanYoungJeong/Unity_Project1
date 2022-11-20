using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInfo : MonoBehaviour
{
    public Image itemImage;
    public Text itemName;
    public Text rank;
    public Text status;
    public Text stat1Name;
    public Text stat2Name;
    public Text stat1Val;
    public Text stat2Val;
    public Text upgradeRate;

    public void ViewItem(Sprite _image, string _itemName, string _rank, 
                        string _status, string _stat1Name, string _stat2Name,
                        string _stat1Val, string _stat2Val, string _upgradeRate)

    {
        itemImage.sprite = _image;
        itemName.text = _itemName;
        rank.text = _rank;
        status.text = _status;
        stat1Name.text = _stat1Name;
        stat2Name.text = _stat2Name;
        stat1Val.text = _stat1Val;
        stat2Val.text = _stat2Val;
        upgradeRate.text = "+" + _upgradeRate;
    }

    public void changeStatView(Equipment item)
    {
        stat1Val.text = item.stat1.ToString();
        stat2Val.text = item.stat2.ToString();
        upgradeRate.text = "+" + item.upgrade.ToString();
    }

}
