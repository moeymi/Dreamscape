using UnityEditor;
using UnityEngine;

public class BodyPartSlot_UI : InventorySlot_UI
{
    [SerializeField]
    private string partType;

    public override void SetHandler(ItemDragHandler newHandler)
    {
        if (newHandler.parentSlot.GetType() == typeof(BodyPartSlot_UI))
            return;

        if (currentHandler.Item != null)
        {
            InventoryManager.Instance.UnequipBodyPart(currentHandler.Item as BodyPart_SO);
        }
        if (newHandler.Item != null)
        {
            InventoryManager.Instance.EquipBodyPart(newHandler.Item as BodyPart_SO);
        }


        base.SetHandler(newHandler);

    }
}
