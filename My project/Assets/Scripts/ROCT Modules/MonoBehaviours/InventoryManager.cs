using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    Inventory inventory;

    [SerializeField]
    private Transform itemCellParent;
    private GameObject itemCellPrefab;

    [SerializeField]
    private GameObject itemShadow;

    List<ItemCellManager> cells = new List<ItemCellManager>();

    private void Awake()
    {
        inventory = new Inventory();

        itemCellPrefab = Resources.Load<GameObject>("Prefabs/ItemCell");
        for (int i = 0; i < inventory.Count; i++)
        {
            ItemCellManager cell = Instantiate(itemCellPrefab, itemCellParent).GetComponent<ItemCellManager>();
            cell.Initialize(inventory.cells[i], i);
            cells.Add(cell);
        }

        EventManager.AddEvent("Inventory :: UseItem", (p) =>
        {
            int index = (int)p[0];
            UseItem(index, 1);
        });

        EventManager.AddEvent("Inventory :: BeginDrag", (p) =>
        {
            itemShadow.GetComponent<UnityEngine.UI.Image>().sprite = (Sprite)p[0];
            itemShadow.SetActive(true);
        });

        EventManager.AddEvent("Inventory :: Drag", (p) =>
        {
            itemShadow.transform.position = (Vector2)p[0];
        });

        EventManager.AddEvent("Inventory :: EndDrag", (p) =>
        {
            itemShadow.SetActive(false);
        });

        EventManager.AddEvent("Inventory :: Switching", (p) =>
        {
            int drag = (int)p[0];
            int drop = (int)p[1];
            Switching(drag, drop);
        });

        AddItem("0000", 3);
        AddItem("0001", 3);
        AddItem("0002", 3);
        AddItem("0003", 3);

        //StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            float rnd = Random.Range(0f, 60f);
            if (rnd < 20f)
            {
                AddItem($"000{Random.Range(0, 4)}", Random.Range(2, 20));
            }
            else if (rnd < 40f)
            {
                RemoveItem($"000{Random.Range(0, 4)}", Random.Range(2, 20));
            }
            else if (rnd < 60f)
            {
                Switching(Random.Range(0, 6), Random.Range(0, 6));
            }
        }
    }

    private void AddItem(string code, int count)
    {
        inventory.AddItem(code, count);
        Refresh();
    }

    private void RemoveItem(string code, int count)
    {
        inventory.RemoveItem(code, count);
        Refresh();
    }

    private void Switching(int drag, int drop)
    {
        inventory.Switching(drag, drop);
        Refresh();
    }

    private void UseItem(int index, int count)
    {
        inventory.UseItem(index, count);
        Refresh();
    }

    private void Refresh()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Refresh();
        }
    }
}
