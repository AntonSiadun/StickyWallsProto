using UnityEngine;

public class ReparentModificator : Modificator
{
    private Transform _cachedTransform;

    protected override void OnTouch()
    {
        _cachedTransform = character.transform.parent;
        character.transform.parent = transform;
    }

    protected override void OnLeave()
    {
        character.transform.parent = _cachedTransform;
    }
}
