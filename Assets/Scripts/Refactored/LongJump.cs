using UnityEngine;
using Zenject;
using System;
using AntonSiadun.StickyWallsProto.Domain.Movement.Counters;

namespace AntonSiadun.StickyWallsProto.Domain.Movement.JumpController
{
    public class LongJump : MonoBehaviour, ILongJumpBehaviour
    {
        [SerializeField] private float _jumpDuration;
        [SerializeField] private int _jumpsCount;

        public int CurrentCount;

        private ICharacter _character;
        private ICounter _counter;
        private ITimer _timer;
        private bool _jumpContinue = false;

        private void Update()
        {
            if (_counter != null)
                CurrentCount = _counter.Current;
        }

        [Inject]
        public void Inittialize(ICharacter character, ICounter counter, ITimer timer)
        {
            if (character == null || counter == null || timer == null)
                throw new NullReferenceException();

            _character = character;
            _counter = counter;
            _timer = timer;

            if (_jumpDuration < 0 || _jumpsCount < 0)
                throw new ArgumentException("The long jump params are invalid.");

            _timer.Duration = _jumpDuration;
            _counter.Count = _jumpsCount;

            _timer.Reset();
        }

        public void BaseJump()
        {
            if (_character.IsGrounded)
            {
                _character.Jump();
                _counter.Reset();
                _jumpContinue = true;

                return;
            }
            else if (_counter.Current > 0)
            {
                _character.TurnBack();
                _character.Jump();
                _counter.Decrement();
                _jumpContinue = true;

                return;
            }
        }

        public void AdditionalJump()
        {
            if (_jumpContinue)
            {
                if (_timer.Current > 0)
                {
                    _character.SecondJump();
                    _timer.Substract(Time.deltaTime);
                }
                else
                {
                    _jumpContinue = false;
                    _timer.Reset();
                }
            }
        }

        public void JumpEnd()
        {
            _jumpContinue = false;
        }

    }
}