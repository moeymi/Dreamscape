using UnityEngine;

public abstract class Slot_UI : MonoBehaviour
{
    protected Item_SO currentItem;

    public Item_SO CurrentItem
    {
        get { return currentItem; }
    }
    
    public bool IsEmpty
    {
        get { return currentItem == null; }
    }

    public abstract void SetItem(Item_SO item);
}
