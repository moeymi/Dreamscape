using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]
    private CharacterBody_SO characterBody;

    [SerializeField]
    private int maxSize = 20;

    private List<Item_SO> currentItems;

    public int MaxSize
    {
        get { return maxSize; }
    }

    protected override void Awake()
    {
        base.Awake();
        currentItems = new List<Item_SO>();
        EventsPool.Instance.AddListener(typeof(BuyItemEvent), new Action<Item_SO, float>(AddItem));
    }

    public void AddItem(Item_SO item, float price)
    {
        currentItems.Add(item);
    }

    public void EquipBodyPart(BodyPart_SO bodyPart)
    {
        if (bodyPart.partType == "Clothes")
        {
            characterBody.clothesBodyPart = bodyPart;
        }
        else
        {
            characterBody.headBodyPart = bodyPart;
        }

        EventsPool.Instance.InvokeEvent(typeof(UpdateCharacterPartsEvent));
    }

    public void UnequipBodyPart(BodyPart_SO bodyPart)
    {
        if (bodyPart.partType == "Clothes")
        {
            characterBody.clothesBodyPart = null;
        }
        else
        {
            characterBody.headBodyPart = null;
        }

        EventsPool.Instance.InvokeEvent(typeof(UpdateCharacterPartsEvent));
    }
}
