using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Interactable currentInteractable;


    public void SetInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
    }

    public void RemoveInteractable(Interactable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }

    private void OnInteract()
    {
        currentInteractable?.Interact();
    }
}
