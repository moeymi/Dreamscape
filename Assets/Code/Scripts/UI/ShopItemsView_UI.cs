using TMPro;
using UnityEngine;

public class ShopItemsView_UI : ItemsView_UI
{
    [SerializeField]
    private TextMeshProUGUI actionBtnText;

    private Shop_SO shop;
    private bool isBuying;

    private Item_SO selectedItem;

    public void KeepSelected(Slot_UI selectedSlot)
    {
        selectedItem = selectedSlot.CurrentItem;
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
        Show(InventoryManager.Instance.CurrentItems.ToArray());
    }

    public void Show(Shop_SO shop)
    {
        this.shop = shop;
        isBuying = true;
        actionBtnText.text = "Buy";
        Show(shop.shopItems);
    }

    public void Show(Item_SO[] items)
    {
        int ind = 0;
        for (ind = 0; ind < Mathf.Min(viewSlots.Count, items.Length); ind++)
        {
            viewSlots[ind].SetItem(items[ind]);
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
            Debug.Log("Buy");
        }
        else
        {
            Debug.Log("Sell");
        }
    }
}
