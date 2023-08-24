using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Interactable currentInteractable;


    public void SetInteractable(Interactable interactable)
    {
        currentInteractable?.TurnOff();
        currentInteractable = interactable;
    }

    public void RemoveInteractable(Interactable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable?.TurnOff();
            currentInteractable = null;
        }
    }

    private void OnInteract()
    {
        currentInteractable?.Interact();
    }
}
