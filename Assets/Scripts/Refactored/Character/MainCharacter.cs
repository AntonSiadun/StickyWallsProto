using UnityEngine;
using Zenject;
using System;
using AntonSiadun.StickyWallsProto.Domain.Movement.Services;

namespace AntonSiadun.StickyWallsProto.Domain.Movement
{
    public class MainCharacter : MonoBehaviour, ICharacter
    {
        public bool IsGrounded => GroundCheckService.IsObjectGrounded(transform, _groundCheckRadius);
        public bool Grounded;

        [SerializeField] private float _groundCheckRadius = 1f;
        [SerializeField] private float _secondJumpForceMultipier = 0.1f;

        private IMovement _movement;
        private IGravity _gravity;

        private void Update()
        {
            Grounded = IsGrounded;
            Debug.DrawLine(transform.position, transform.position - new Vector3(0f, _groundCheckRadius, 0f));
        }

        [Inject]
        public void Initialize(IMovement movement, IGravity gravity)
        {
            if (movement == null || gravity == null)
                throw new NullReferenceException();

            _movement = movement;
            _gravity = gravity;
        }

        public void SecondJump()
        {
            _movement.Jump(_secondJumpForceMultipier);
        }

        public void Jump()
        {
            _movement.ResetVelocity();
            _movement.Jump(1f);
        }

        public void Restore()
        {
            _gravity.Restore();
        }

        public void Stop()
        {
            _gravity.Stop();
            _movement.ResetVelocity();
        }

        public void AddClutch(float force)
        {
            _movement.SetVerticalVelocity(force);
        }    

        public void TurnBack()
        {
            _movement.TurnBack();
        }

        public void Pulse(float force)
        {
            _movement.Jump(force);
        }
    }
}