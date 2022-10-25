using UnityEngine;
public class PcInput : InputController
{
    protected override bool isPressedAtWall()
    {
        return Input.GetKeyDown(KeyCode.Space) && character.IsGrounded;
    }

    protected override bool isPressedAndHadExtraJumps()
    {
        return Input.GetKeyDown(KeyCode.Space) && extraJumpsCounter > 0;
    }

    protected override bool isPressingEnded()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }
}
