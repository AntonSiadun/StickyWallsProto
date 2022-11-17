namespace AntonSiadun.StickyWallsProto.Domain.Movement
{
    public interface ICharacter
    {
        public bool IsGrounded { get; }

        public void SecondJump();
        public void Jump();
        public void StopGravity();
        public void RestoreGravity();
        public void TurnBack();
    }
}