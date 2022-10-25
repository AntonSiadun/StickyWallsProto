using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModificator : Modificator
{
    [SerializeField] private float _horizontalVelocity;

    void Start()
    {
        turnBackOnTouch = false;
    }

    protected override void OnLeave()
    {
        base.OnLeave();
    }

    protected override void OnTouch()
    {
        character.SetHorizontalVelocity(_horizontalVelocity * character.Direction);
    }
}
