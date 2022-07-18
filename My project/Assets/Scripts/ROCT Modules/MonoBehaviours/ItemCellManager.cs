using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemCellManager : EventTrigger
{
    ItemCell cell;
    public int index;

    [SerializeField] private Image imgItemImage;
    [SerializeField] private Text txtItemCount;

    //public override void

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            EventManager.SendEvent("Inventory :: UseItem", index);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        EventManager.SendEvent("Inventory :: BeginDrag", cell.data.itemImage);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        EventManager.SendEvent("Inventory :: Drag", eventData.position);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        EventManager.SendEvent("Inventory :: EndDrag");
    }

    public override void OnDrop(PointerEventData eventData)
    {
        // 드래그 시작 : 2번
        // 드랍 : 1번

        int dragIndex = eventData.pointerDrag.GetComponent<ItemCellManager>().index;
        int dropIndex = index;

        EventManager.SendEvent("Inventory :: Switching", dragIndex, dropIndex);
    }

    public void Initialize(ItemCell itemCell, int index)
    {
        this.cell = itemCell;
        this.index = index;
        Refresh();
    }

    public void Refresh()
    {
        imgItemImage.sprite = cell.data.itemImage;
        txtItemCount.text = $"{cell.itemCount}";
    }
}
