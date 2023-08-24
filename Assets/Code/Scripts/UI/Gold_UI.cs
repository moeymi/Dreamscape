using TMPro;
using UnityEngine;

public class Gold_UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI amountText;

    private string text;

    void LateUpdate()
    {
        text = InventoryManager.Instance.GoldAmount.ToString();
        amountText.text = text;
    }
}
