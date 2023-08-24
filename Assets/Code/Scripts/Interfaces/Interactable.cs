using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;

    private void Awake()
    {
        indicator?.SetActive(false);
    }

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        PlayerInputHandler playerInputHandler;
        if(collision.transform.root.TryGetComponent(out playerInputHandler))
        {
            playerInputHandler.SetInteractable(this);
            indicator?.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInputHandler playerInputHandler;
        if (collision.transform.root.TryGetComponent(out playerInputHandler))
        {
            playerInputHandler.RemoveInteractable(this);
            indicator?.SetActive(false);
        }
    }

    public void TurnOff()
    {
        indicator?.SetActive(false);
    }
}
