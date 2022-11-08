using UnityEngine;
using Zenject;
using System;

public class InputActionInterpretator : MonoBehaviour, ILongJumpBehaviour
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

    public void BaseJump() 
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

    public void AdditionalJump() 
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

    public void JumpEnd()
    {
        _counter.Reset();
        _inJump = false;
    }

}
