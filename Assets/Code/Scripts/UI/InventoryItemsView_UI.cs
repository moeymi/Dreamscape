using System;
using UnityEngine;

public class InventoryItemsView_UI : ItemsView_UI
{
    protected void Start()
    {
        var invItems = InventoryManager.Instance.CurrentItems;
        SetItems(invItems.ToArray());

        EventsPool.Instance.AddListener(typeof(BuyItemEvent), new Action<Item_SO, int>(
            (Item_SO item, int _) => AddItem(item)
        ));

        EventsPool.Instance.AddListener(typeof(SellItemEvent), new Action<Item_SO, int>(
            (Item_SO item, int _) => RemoveItem(item)
        ));
    }

}
