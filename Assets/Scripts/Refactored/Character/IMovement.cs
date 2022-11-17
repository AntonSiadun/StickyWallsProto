using UnityEngine;

namespace AntonSiadun.StickyWallsProto.Domain.Movement
{
    public interface IMovement
    {
        public Vector2 Direction { get; }

        public void Jump(float force);
        public void TurnBack();
        public void ResetVelocity();
    }
}