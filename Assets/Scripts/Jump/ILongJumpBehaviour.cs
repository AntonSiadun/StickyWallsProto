namespace Domain.Movement.JumpController
{
    public interface ILongJumpBehaviour
    {
        public void BaseJump();
        public void AdditionalJump();
        public void JumpEnd();
    }
}