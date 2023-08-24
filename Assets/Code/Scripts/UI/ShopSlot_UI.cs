using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot_UI : Slot_UI, IPointerClickHandler
{
    private bool isSelected = false;

    private ShopItemsView_UI shopPanel;
    private Image iconImage;

    private Image slotImage;
    private Color originalColor;

    private void Awake()
    {
        iconImage = transform.GetChild(0).GetComponent<Image>();
        slotImage = GetComponentInChildren<Image>();

        originalColor = slotImage.color;
    }

    private void Start()
    {
        shopPanel = GetComponentInParent<ShopItemsView_UI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = true;
        slotImage.color = new Color(1, 1, 1, 0.2f);
        iconImage.color = new Color(1, 1, 1, 0.2f);
        shopPanel.KeepSelected(this);
    }

    public override void SetItem(Item_SO item)
    {
        currentItem = item;
        iconImage.enabled = item != null;
        iconImage.sprite = item == null ? null : item.itemSprite;
    }

    public void Unselect()
    {
        iconImage.color = new Color(1, 1, 1, 1f);
        slotImage.color = originalColor;
    }
}
