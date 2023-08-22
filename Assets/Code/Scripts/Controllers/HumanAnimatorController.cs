using UnityEngine;

public class HumanAnimatorController : AnimatorController
{
    public void SetVelocity(Vector2 velocity)
    {
        animator.SetFloat("Velocity", velocity.sqrMagnitude);
        if (velocity.sqrMagnitude > 0.01)
        {
            animator.SetFloat("Move_X", velocity.x);
            animator.SetFloat("Move_Y", velocity.y);
        }
    }
}
