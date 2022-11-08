using UnityEngine;

public class MobileInputSignature : IConcreteInputSignature
{
    public bool IsPressed()
    {
        return Input.touchCount == 0;
    }

    public bool IsPressEnded()
    {
        return Input.GetTouch(0).phase == TouchPhase.Ended;
    }

    public bool IsPressStarted()
    {
        return Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
