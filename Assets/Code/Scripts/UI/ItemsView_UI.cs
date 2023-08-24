using System.Collections.Generic;
using UnityEngine;

public class ItemsView_UI : MonoBehaviour
{
    [SerializeField]
    private RectTransform itemsContentView;

    [SerializeField]
    private Slot_UI itemSlotPrefab;

    protected Dictionary<Item_SO, Slot_UI> currentItems;
    protected List<Slot_UI> viewSlots;

    protected int maxSize = 20;

    protected virtual void Awake()
    {
        currentItems = new Dictionary<Item_SO, Slot_UI>();
        viewSlots = new List<Slot_UI>();

        for (int i = 0; i < maxSize; i++)
        {
            var newSlot = Instantiate(itemSlotPrefab, itemsContentView);
            newSlot.name = i.ToString();
            newSlot.SetItem(null);
            viewSlots.Add(newSlot);
        }
    }

    public void AddItem(Item_SO item)
    {
        foreach (var slot in viewSlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                currentItems.Add(item, slot);
                break;
            }
        }
    }

    public void RemoveItem(Item_SO item)
    {
        currentItems[item].SetItem(null);
        currentItems.Remove(item);
    }
}
