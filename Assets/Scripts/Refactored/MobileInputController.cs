using System;
using UnityEngine;

public class MobileInputController : MonoBehaviour, IInput
{
    public event Action OnTap;
    public event Action OnLongPress;
    public event Action OnEnded;

    private void Update()
    {

        if (Input.touchCount == 0)
            return;

        if( Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnTap?.Invoke();
            return;
        }

        if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            OnEnded?.Invoke();
            return;
        }

        OnLongPress?.Invoke();
    }
}
