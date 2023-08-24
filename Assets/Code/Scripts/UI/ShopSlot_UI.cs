using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot_UI : Slot_UI, IPointerClickHandler
{
    private bool isSelected = false;

    private ShopItemsView_UI shopPanel;
    private Image iconImage;
    private TextMeshProUGUI priceText;

    private Image slotImage;
    private Color originalColor;
    private bool available;

    private void Awake()
    {
        iconImage = transform.GetChild(0).GetComponent<Image>();
        slotImage = GetComponentInChildren<Image>();
        priceText = GetComponentInChildren<TextMeshProUGUI>();

        originalColor = slotImage.color;
        available = true;
    }

    private void Start()
    {
        shopPanel = GetComponentInParent<ShopItemsView_UI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!available || currentItem == null)
        {
            return;
        }
        isSelected = true;
        slotImage.color = new Color(0, 0, 0, 0.8f);
        iconImage.color = new Color(0, 0, 0, 0.8f);
        shopPanel.KeepSelected(this, int.Parse(priceText.text));
    }

    public override void SetItem(Item_SO item)
    {
        currentItem = item;
        priceText.enabled = item != null;
        iconImage.enabled = item != null;
        iconImage.sprite = item == null ? null : item.itemSprite;
    }

    public void SetItem(ShopItem item)
    {
        priceText.text = item.price.ToString();
        available = true;

        slotImage.color = new Color(1, 1, 1, 1);
        iconImage.color = new Color(1, 1, 1, 1);
        SetItem(item.item);
    }

    public void Unselect()
    {
        if (!available)
            return;

        iconImage.color = new Color(1, 1, 1, 1f);
        slotImage.color = originalColor;
    }

    public void MakeUnavailable()
    {
        available = false;
        slotImage.color = new Color(1, 1, 1, 0.2f);
        iconImage.color = new Color(1, 1, 1, 0.2f);
    }
}
