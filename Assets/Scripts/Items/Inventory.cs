using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ItemCategory { Items, Farming, Materials, Mining, Others}

public class Inventory : MonoBehaviour
{
    #region Variables

    [SerializeField] List<ItemSlot> slots;
    [SerializeField] List<ItemSlot> landSlots;
    [SerializeField] List<ItemSlot> materialSlots;
    [SerializeField] List<ItemSlot> MineSlots;
    [SerializeField] List<ItemSlot> potionSlots;
    [SerializeField] List<ItemSlot> otherSlots;

    List<List<ItemSlot>> allSlots;

    public event Action OnUpdated;

    #endregion

    #region Methods
    private void Awake()
    {
        allSlots = new List<List<ItemSlot>>() { slots, landSlots, materialSlots, MineSlots, otherSlots };
    }

    public static List<string> ItemCategories { get; set; } = new List<string>()
    {
        "ITEMS", "FARMING", "MATERIALS", "MINING", "OTHERS"
    };

    public List<ItemSlot> GetSlotsByCategory(int categoryIndex)
    {
        return allSlots[categoryIndex];
    }

    public ItemBase GetItem(int itemIndex, int categoryIndex)
    {
        var currenSlots = GetSlotsByCategory(categoryIndex);
        return currenSlots[itemIndex].Item;
    }

    public static Inventory GetInventory()
    {
       return FindObjectOfType<PlayerController>().GetComponent<Inventory>();
    }

    public void AddItem(ItemBase item, int count=1)
    {
        int category = (int)GetCategoryFromItem(item);
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = currentSlots.FirstOrDefault(slot => slot.Item == item);
        if (itemSlot != null)
        {
            itemSlot.Count += count;
        }
        else
        {
            currentSlots.Add(new ItemSlot()
            {
                Item = item,
                Count = count
            });
        }

        OnUpdated?.Invoke();

    }

    public int GetItemCount(ItemBase item)
    {
        int category = (int)GetCategoryFromItem(item);
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = currentSlots.FirstOrDefault(slot => slot.Item == item);

        if (itemSlot != null)
            return itemSlot.Count;
        else
            return 0;
    }

    public void RemoveItem(ItemBase item, int countToRemove = 1)
    {
        int category = (int)GetCategoryFromItem(item);
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = currentSlots.First(slot => slot.Item == item);
        itemSlot.Count -= countToRemove;
        if (itemSlot.Count == 0)
            currentSlots.Remove(itemSlot);

        OnUpdated?.Invoke();
    }

    ItemCategory GetCategoryFromItem(ItemBase item)
    {
        if (item is HarvestingItems)
            return ItemCategory.Items;
        else if (item is LandItems)
            return ItemCategory.Farming;
        else if (item is TreeItems)
            return ItemCategory.Materials;
        else if (item is MinesItems)
            return ItemCategory.Mining;
        else
            return ItemCategory.Others;
    }

    #endregion
}

#region Others

[Serializable]
public class ItemSlot
{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    public ItemBase Item
    {
        get => item;
        set => item = value;
    }
    public int Count
    {
        get => count;
        set => count = value;
    }
}

#endregion
