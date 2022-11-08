using UnityEngine;
using System;

public class InputControlBindService : MonoBehaviour
{
    public static void Bind(IInput input , ILongJumpBehaviour jumpControl)
    {
        if( input == null || jumpControl == null)
            throw new NullReferenceException();

        input.OnTap += jumpControl.BaseJump;
        input.OnLongPress += jumpControl.AdditionalJump;
        input.OnEnded += jumpControl.JumpEnd;
    }
}
