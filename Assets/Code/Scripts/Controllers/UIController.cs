using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup inventoryPanel;

    [SerializeField]
    private ShopItemsView_UI shopPanel;

    private void Awake()
    {
        inventoryPanel.alpha = 0;
        inventoryPanel.interactable = false;

        shopPanel.gameObject.SetActive(false);

        EventsPool.Instance.AddListener(typeof(ShowShopEvent), new Action<Shop_SO>(ShowShop));
    }

    private void ShowShop(Shop_SO shop)
    {
        inventoryPanel.alpha = 0;
        inventoryPanel.interactable = false;

        shopPanel.gameObject.SetActive(true);
        shopPanel.Show(shop);
    }

    private void OnInventory()
    {
        if (!shopPanel.gameObject.activeSelf)
        {
            inventoryPanel.interactable = !inventoryPanel.interactable;
            inventoryPanel.alpha = inventoryPanel.interactable ? 1 : 0;
        }
    }
}
