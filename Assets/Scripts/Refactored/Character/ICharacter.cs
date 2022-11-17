namespace AntonSiadun.StickyWallsProto.Domain.Movement
{
    public interface ICharacter
    {
        public bool IsGrounded { get; }

        public void SecondJump();
        public void Jump();
        public void Stop();
        public void Restore();
        public void AddClutch(float force);
        public void TurnBack();
    }
}