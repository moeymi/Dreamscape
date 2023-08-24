using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsView_UI : MonoBehaviour
{
    [SerializeField]
    private RectTransform itemsContentView;

    [SerializeField]
    private Slot_UI itemSlotPrefab;

    protected List<Slot_UI> viewSlots;

    protected int maxSize = 20;

    protected virtual void Awake()
    {
        viewSlots = new List<Slot_UI>();

        for (int i = 0; i < maxSize; i++)
        {
            var newSlot = Instantiate(itemSlotPrefab, itemsContentView);
            newSlot.name = i.ToString();
            newSlot.SetItem(null);
            viewSlots.Add(newSlot);
        }
    }

    public void SetItems(Item_SO[] items)
    {
        int ind = 0;
        for (ind = 0; ind < Mathf.Min(viewSlots.Count, items.Length); ind++)
        {
            viewSlots[ind].SetItem(items[ind]);
        }

        while (ind < viewSlots.Count)
        {
            viewSlots[ind++].SetItem(null);
        }
    }

    public void AddItem(Item_SO item)
    {
        foreach (var slot in viewSlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    public void RemoveItem(Item_SO item)
    {
        var slot = viewSlots.Find((Slot_UI slot) => item == slot.CurrentItem);
        slot.SetItem(null);
    }
}
