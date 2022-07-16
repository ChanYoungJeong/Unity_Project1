using System;

public class Inventory
{
    public ItemCell[] cells;
    public int Count => cells.Length;

    public Inventory()
    {
        cells = new ItemCell[6];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = new ItemCell();
        }
    }
    
    public void AddItem(string code, int count)
    {
        bool added = false;
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].data.itemCode == code)
            {
                cells[i].itemCount += count;
                added = true;
                break;
            }
        }
        if (!added)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].itemCount <= 0)
                {
                    cells[i].data = ItemManager.GetItem(code);
                    cells[i].itemCount = count;
                    added = true;
                    break;
                }
            }
        }
    }

    public void RemoveItem(string code, int count)
    {
        int index = Array.FindIndex(cells, e => e.data.itemCode == code);
        RemoveItem(index, count);
    }

    public void RemoveItem(int index, int count)
    {
        if (index != -1)
        {
            if (cells[index].itemCount > count)
            {
                cells[index].itemCount -= count;
            }
            else
            {
                cells[index].SetCell(new ItemCell());
            }
        }
    }

    public void Switching(int drag, int drop)
    {
        ItemCell newItemCell = new ItemCell();

        newItemCell.SetCell(cells[drag]);
        cells[drag].SetCell(cells[drop]);
        cells[drop].SetCell(newItemCell);
    }

    public void UseItem(int index, int count)
    {
        cells[index].data.UseItem();
        RemoveItem(index, count);
    }

    public void Print()
    {
#if UNITY_EDITOR
        for (int i = 0; i < cells.Length; i++)
        {
            UnityEngine.Debug.Log($"{i} :: <b><color=#ffc022>{cells[i].data.itemName}</color></b> :: <b><color=#22c0ff>{cells[i].itemCount}</color></b>");
        }
#endif
    }
}
