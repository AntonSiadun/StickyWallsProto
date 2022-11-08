using UnityEngine;

public class PCInputSignature : IConcreteInputSignature
{
    public bool IsPressed()
    {
        return Input.anyKey;
    }

    public bool IsPressEnded()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }

    public bool IsPressStarted()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
