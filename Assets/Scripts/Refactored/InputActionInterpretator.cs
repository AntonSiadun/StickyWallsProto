using UnityEngine;
using Zenject;
using System;

public class InputActionInterpretator : MonoBehaviour
{
    private ICharacter _character;
    private IInput _input;
    private IOngoingActionCounter _counter;
    private bool _inJump = false;

    [Inject]
    public void Initialize(IInput input,ICharacter character)
    {
        _input = input;
        _character = character;
    }

    private void Start()
    {
        if (_input == null || _character == null)
            throw new NullReferenceException();

        _input.OnTap += JumpScript;
        _input.OnLongPress += AdditionalJumpScript;
        _input.OnEnded += JumpEndScript;
    }

    private void JumpScript() 
    {
        if ( _character.IsGrounded)
        {
            _counter.ZeroOut();
            _inJump = true;
            return;
        }
        else if (_counter.Count > 0)
        {
            _character.TurnBack();
            _counter.Decrement();
            _inJump = true;
            return;
        }
    }

    //IN_JUMP - > FOR WHAT ??!!!
    private void AdditionalJumpScript() 
    {
        if (_inJump)
        {
            if (_counter.Time > 0)
            {
                _character.AdditionalJump();
                _counter.Substract(Time.deltaTime);
            }
            else
            {
                _inJump = false;
                _counter.Reset();
            }
        }
    }

    private void JumpEndScript()
    {
        _counter.Reset();
        _inJump = false;
    }

}
