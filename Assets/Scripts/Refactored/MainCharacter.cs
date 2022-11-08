using UnityEngine;

public class MainCharacter : MonoBehaviour, ICharacter
{
    public bool IsGrounded => true;

    private IMovement _movement;
    private IGravity _gravity;

    public void AdditionalJump()
    {
        _movement.AdditionalJump();
    }

    public void Jump()
    {
        _movement.Jump();          
    }

    public void RestoreGravity()
    {
        _gravity.Restore();
    }

    public void StopGravity()
    {
        _gravity.Stop();
    }

    public void TurnBack()
    {
        /////////////////////////////??????????????????
    }
}
