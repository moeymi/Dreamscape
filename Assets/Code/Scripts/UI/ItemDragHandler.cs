using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image imageComponent;
    private Transform canvasTransform;
    private Item_SO item;

    [HideInInspector]
    public InventorySlot_UI parentSlot;

    public Item_SO Item
    {
        get { return item; }
    }

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        parentSlot = GetComponentInParent<InventorySlot_UI>();
    }


    private void Start()
    {
        canvasTransform = transform.root;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (imageComponent.enabled)
        {
            imageComponent.raycastTarget = false;
            transform.SetParent(canvasTransform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(imageComponent.enabled)
            transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (imageComponent.enabled)
        {
            transform.SetParent(parentSlot.transform, false);
            transform.localPosition = Vector3.zero;
            imageComponent.raycastTarget = true;
        }
    }

    public void Drop(InventorySlot_UI slot)
    {
        parentSlot = slot;

        transform.SetParent(parentSlot.transform, false);
        transform.localPosition = Vector3.zero;
    }

    public void SetItem(Item_SO newItem)
    {
        item = newItem;
        imageComponent.sprite = item != null ? item.itemSprite : null;
        imageComponent.enabled = item != null ? true : false;
    }

    public void ToggleImage(bool showImage)
    {
        imageComponent.enabled = showImage;
    }
}
