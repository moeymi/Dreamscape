using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
public class Shop_SO : ScriptableObject
{
    public string shopName;

    public Item_SO[] shopItems;
}
