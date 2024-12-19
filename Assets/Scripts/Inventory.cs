using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс отвечает за хранение предмета
public class Inventory : MonoBehaviour
{
    public event Action<List<ItemData>> onInventoryChanged;
    private List<ItemData> items = new List<ItemData>();

    public void AddItem(Item item, int count)
    {
        int index = items.FindIndex(obj => obj.item == item);
        if (index != -1)
        {
            items[index].count += count;
        }
        else
        {
            items.Add(new ItemData(item, count));
        }
        onInventoryChanged.Invoke(items);
    }

    public void RemoveItem(Item item, int count)
    {
        int index = items.FindIndex(obj => obj.item == item);
        if (index != -1)
        {
            items[index].count -= count;
            if (items[index].count <= 0)
            {
                items.RemoveAt(index);
            }
            onInventoryChanged.Invoke(items);
        }
        else
        {
            Debug.Log($"No {item} exist in inventory");
        }
    }
}
[System.Serializable]
public class ItemData
{
    public Item item;
    public int count;

    public ItemData() { }

    public ItemData(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
}
