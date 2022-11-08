using System;
using UnityEngine;
using Zenject;

public class MobileInputController : MonoBehaviour, IInput
{
    public event Action OnTap;
    public event Action OnLongPress;
    public event Action OnEnded;

    private IConcreteInputSignature _concreteInput;

    [Inject]
    public void Initialize(IConcreteInputSignature concreteInput)
    {
        _concreteInput = concreteInput;
    }

    private void Update()
    {

        if (!_concreteInput.IsPressed())
            return;

        if( _concreteInput.IsPressStarted() )
        {
            OnTap?.Invoke();
            return;
        }

        if(_concreteInput.IsPressEnded())
        {
            OnEnded?.Invoke();
            return;
        }

        OnLongPress?.Invoke();
    }
}
