using UnityEngine;

public class MovementMobileInput : InputController
{
    private bool isPressed()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
    
    protected override bool isPressedAtWall()
    {
        return isPressed() && character.IsGrounded;
    }

    protected override bool isPressedAndHadExtraJumps()
    {
        return isPressed() && extraJumpsCounter > 0;
    }

    protected override bool isPressingEnded()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }
}
