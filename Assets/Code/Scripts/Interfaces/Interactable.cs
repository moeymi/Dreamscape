using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        PlayerInputHandler playerInputHandler;
        if(collision.transform.root.TryGetComponent(out playerInputHandler))
        {
            playerInputHandler.SetInteractable(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInputHandler playerInputHandler;
        if (collision.transform.root.TryGetComponent(out playerInputHandler))
        {
            playerInputHandler.RemoveInteractable(this);
        }
    }
}
