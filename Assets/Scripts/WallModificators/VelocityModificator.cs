using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityModificator : Modificator
{
    [SerializeField] private float _verticalVelocity;

    protected override void OnTouch()
    {
        character.SetVerticalVelocity(_verticalVelocity);
    }   
}
