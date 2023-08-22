using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    #region Attributes

    [SerializeField]
    [Range(0f, 5f)]
    private float moveSpeed = 5;

    #endregion

    #region Private

    private Rigidbody2D rb;
    private Vector2 velocityVector;
    private Vector2 moveVector;
    private HumanAnimatorController playerAnimController;

    #endregion

    #region MonoBehaviour

    void Awake()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        velocityVector = moveVector * moveSpeed;
        velocityVector = Vector2.ClampMagnitude(velocityVector, moveSpeed);

        rb.velocity = velocityVector;
        playerAnimController.SetVelocity(moveVector);
    }

    #endregion

    #region Methods

    private void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimController = GetComponentInChildren<HumanAnimatorController>();
    }

    // Used by the Player Input Component
    private void OnMove(InputValue inputValue)
    {
        moveVector = inputValue.Get<Vector2>();
    }

    #endregion
}
