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


    public void ViewItem(Sprite _image, Equipment item, string _status)
    {
        itemImage.sprite = _image;
        itemName.text = item.name;
        rank.text = item.grade;
        status.text = _status;
        StatNameByType(item.type);
        stat1Val.text = item.stat1.ToString();
        stat2Val.text = item.stat2.ToString();
        upgradeRate.text = "+" + item.upgrade.ToString();
    }

    private void StatNameByType(string type)
    {
        string _stat1Name = "";
        string _stat2Name = "";
        if(type == "Weapon")
        {
            _stat1Name = "Attack";
            _stat2Name = "Critical Rate";
        }
        else if(type == "Armor")
        {
            _stat1Name = "Hp";
            _stat2Name = "Armor";
        }

        stat1Name.text = _stat1Name;
        stat2Name.text = _stat2Name;
    }

    public void changeStatView(Equipment item)
    {
        stat1Val.text = item.stat1.ToString();
        stat2Val.text = item.stat2.ToString();
        upgradeRate.text = "+" + item.upgrade.ToString();
    }

}
