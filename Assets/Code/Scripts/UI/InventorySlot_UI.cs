using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot_UI : MonoBehaviour, IDropHandler
{
    protected ItemDragHandler currentHandler;

    public bool IsEmpty
    {
        get { return currentHandler.Item == null; }
    }

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

    public void SetItem(Item_SO item)
    {
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
