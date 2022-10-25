using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineModificator : Modificator
{
    [SerializeField] private float _repellingForce = 1f;
    protected override void OnTouch()
    {
        character.Jump(_repellingForce);
    }
}
