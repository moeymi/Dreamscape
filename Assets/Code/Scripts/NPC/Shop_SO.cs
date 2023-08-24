using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
public class Shop_SO : ScriptableObject
{
    public string shopName;

    public ShopItem[] shopItems;
}

[Serializable]
public class ShopItem
{
    public int price;
    public Item_SO item;
}
