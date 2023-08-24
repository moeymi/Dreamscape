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

    private int goldAmount = 100;

    public int GoldAmount
    {
        get { return goldAmount; }
    }

    public int MaxSize
    {
        get { return maxSize; }
    }

    public List<Item_SO> CurrentItems
    { get { return currentItems; } }

    protected override void Awake()
    {
        base.Awake();
        currentItems = new List<Item_SO>();
        EventsPool.Instance.AddListener(typeof(BuyItemEvent), new Action<Item_SO, int>(BuyItem));
        EventsPool.Instance.AddListener(typeof(SellItemEvent), new Action<Item_SO, int>(SellItem));
    }

    private void BuyItem(Item_SO item, int price)
    {
        goldAmount -= price;
        AddItem(item);
    }

    private void SellItem(Item_SO item, int price)
    {
        goldAmount += price;
        RemoveItem(item);
    }

    public void AddItem(Item_SO item)
    {
        currentItems.Add(item);
    }

    public void RemoveItem(Item_SO item)
    {
        currentItems.Remove(item);
    }

    public void EquipBodyPart(BodyPart_SO bodyPart)
    {
        RemoveItem(bodyPart);
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
        AddItem(bodyPart);
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
