using UnityEngine;

public class Merchant_NPC : NPC
{
    [SerializeField]
    private Shop_SO merchantShop;

    public override void Interact()
    {
        EventsPool.Instance.InvokeEvent(typeof(ShowShopEvent), merchantShop);
    }
}
