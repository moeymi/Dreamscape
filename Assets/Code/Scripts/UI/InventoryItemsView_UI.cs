using System;

public class InventoryItemsView_UI : ItemsView_UI
{
    protected override void Awake()
    {
        base.Awake();

        EventsPool.Instance.AddListener(typeof(BuyItemEvent), new Action<Item_SO, float>(OnBuyItem));
    }

    private void OnBuyItem(Item_SO item, float price)
    {
        AddItem(item);
    }
}
