using UnityEngine;
using System;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement.JumpController;
using AntonSiadun.StickyWallsProto.Domain.Movement.Input;

namespace AntonSiadun.StickyWallsProto.Domain.Services
{
    public class InputControlBindService : MonoBehaviour
    {
        private IInput _input;
        private ILongJumpBehaviour _jumpControl;

        [Inject]
        public void Initialize(IInput input, ILongJumpBehaviour jumpControl)
        {
            if (input == null || jumpControl == null)
                throw new NullReferenceException();

            _input = input;
            _jumpControl = jumpControl;
        }

        private void Start()
        {
            Bind();
        }

        public void Bind()
        {
            _input.OnTap += _jumpControl.BaseJump;
            _input.OnLongPress += _jumpControl.AdditionalJump;
            _input.OnEnded += _jumpControl.JumpEnd;
        }
    }
}