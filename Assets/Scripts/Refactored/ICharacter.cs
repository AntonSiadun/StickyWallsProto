public interface ICharacter 
{
    public bool IsGrounded { get; }

    public void AdditionalJump();
    public void Jump();
    public void StopGravity();
    public void RestoreGravity();
    public void TurnBack();
}
