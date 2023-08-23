using UnityEngine;

public class UIController : MonoBehaviour
{
    private Inventory_UI inventory;

    private void Awake()
    {
        inventory = GetComponentInChildren<Inventory_UI>();
    }

    private void OnInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    }
}
