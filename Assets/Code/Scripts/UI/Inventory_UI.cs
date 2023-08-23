using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField]
    private RectTransform itemsContentView;

    [SerializeField]
    private InventorySlot_UI inventoryItemSlotPrefab;

    private Dictionary<Item_SO, InventorySlot_UI> currentItems;
    private List<InventorySlot_UI> inventorySlots;

    private void Awake()
    {
        currentItems = new Dictionary<Item_SO, InventorySlot_UI>();
        inventorySlots = new List<InventorySlot_UI>();

        for (int i = 0;i < InventoryManager.Instance.MaxSize;i++)
        {
            var newSlot = Instantiate(inventoryItemSlotPrefab);
            newSlot.name = i.ToString();
            newSlot.SetItem(null);
            newSlot.transform.SetParent(itemsContentView, false);

            inventorySlots.Add(newSlot);
        }

        EventsPool.Instance.AddListener(typeof(BuyItemEvent), new Action<Item_SO, float>(OnBuyItem));
    }

    private void OnBuyItem(Item_SO item, float price)
    {
        AddItem(item);
    }

    public void AddItem(Item_SO item)
    {
        foreach(var slot in inventorySlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                currentItems.Add(item, slot);
                break;
            }
        }
    }

    public void RemoveItem(Item_SO item)
    {
        currentItems[item].SetItem(null);
        currentItems.Remove(item);
    }
}
