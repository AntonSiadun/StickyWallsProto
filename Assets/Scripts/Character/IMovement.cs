﻿using UnityEngine;

namespace Domain.Movement
{
    public interface IMovement
    {
        public Vector2 Direction { get; }

        public void Jump(float force);
        public void TurnBack();
        public void SetVerticalVelocity(float velocity);
        public void ResetVelocity();
    }
}