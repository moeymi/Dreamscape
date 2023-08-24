using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot_UI : Slot_UI, IDropHandler
{
    protected ItemDragHandler currentHandler;

    private void Awake()
    {
        currentHandler = GetComponentInChildren<ItemDragHandler>();
    }

    public virtual void SetHandler(ItemDragHandler newHandler)
    {
        currentHandler = newHandler;
        currentHandler.Drop(this);
        currentHandler.SetItem(currentHandler.Item);
    }

    public override void SetItem(Item_SO item)
    {
        currentItem = item;
        currentHandler.SetItem(item);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler newHandler;
        if (eventData.pointerDrag.TryGetComponent(out newHandler))
        {
            newHandler.parentSlot.SetHandler(currentHandler);
            SetHandler(newHandler);
        }
    }
}
