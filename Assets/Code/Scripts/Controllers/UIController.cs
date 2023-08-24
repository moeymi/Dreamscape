using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private InventoryItemsView_UI inventoryPanel;

    [SerializeField]
    private ShopItemsView_UI shopPanel;

    private void Awake()
    {
        inventoryPanel.gameObject.SetActive(false);
        shopPanel.gameObject.SetActive(false);

        EventsPool.Instance.AddListener(typeof(ShowShopEvent), new Action<Shop_SO>(ShowShop));
    }

    private void ShowShop(Shop_SO shop)
    {
        inventoryPanel.gameObject.SetActive(false);
        shopPanel.gameObject.SetActive(true);

        shopPanel.Show(shop);
    }

    private void OnInventory()
    {
        inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
    }
}
