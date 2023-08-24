using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopItemsView_UI : ItemsView_UI
{
    [SerializeField]
    private TextMeshProUGUI actionBtnText;

    private Shop_SO shop;
    private bool isBuying;

    private Item_SO selectedItem;
    private int selectedPrice;

    public void KeepSelected(Slot_UI selectedSlot, int selectedPrice)
    {
        selectedItem = selectedSlot.CurrentItem;
        this.selectedPrice = selectedPrice;
        selectedPrice = shop.shopItems.ToList().Find((ShopItem shopItem) => shopItem.item == selectedItem).price;
        foreach (var slot in viewSlots)
        {
            if(slot != selectedSlot)
            {
                (slot as ShopSlot_UI).Unselect();
            }
        }
    }

    public void ShowShop()
    {
        Show(shop);
    }

    public void ShowInventory()
    {
        isBuying = false;
        actionBtnText.text = "Sell";

        List<ShopItem> items = new List<ShopItem>();
        foreach(var item in InventoryManager.Instance.CurrentItems)
        {
            bool found = false;
            foreach(var shopItem in shop.shopItems)
            {
                if (shopItem.item == item)
                {
                    found = true;
                    var newShopItem = new ShopItem()
                    {
                        item = item,
                        price = shopItem.price / 2,
                    };
                    items.Add(newShopItem);
                    break;
                }
            }

            if (!found)
            {
                var newShopItem = new ShopItem()
                {
                    item = item,
                    price = 7,
                };
                items.Add(newShopItem);
            }
        }
        Show(items.ToArray());
    }

    public void Show(Shop_SO shop)
    {
        this.shop = shop;
        isBuying = true;
        actionBtnText.text = "Buy";
        Show(shop.shopItems);
    }

    public void Show(ShopItem[] items)
    {
        int ind = 0;
        for (ind = 0; ind < Mathf.Min(viewSlots.Count, items.Length); ind++)
        {
            (viewSlots[ind] as ShopSlot_UI).SetItem(items[ind]);

            if(items[ind].price > InventoryManager.Instance.GoldAmount)
                (viewSlots[ind] as ShopSlot_UI).MakeUnavailable();
        }

        while (ind < viewSlots.Count)
        {
            viewSlots[ind++].SetItem(null);
        }
    }

    public void MakeAction()
    {
        if(selectedItem == null)
        {
            return;
        }
        if(isBuying)
        {
            if(selectedPrice <= InventoryManager.Instance.GoldAmount)
            {
                EventsPool.Instance.InvokeEvent(typeof(BuyItemEvent), selectedItem, selectedPrice);
            }
            Debug.Log("Buy");
        }
        else
        {
            EventsPool.Instance.InvokeEvent(typeof(SellItemEvent), selectedItem, selectedPrice);
            RemoveItem(selectedItem);
            Debug.Log("Sell");
        }
    }
}
