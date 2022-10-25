public interface IMovingCharacter 
{
    public void Jump(float multipier);
    public void TurnBack();
    public void Snap();
    public void Unsnap();
    public bool IsGrounded {get;}
}