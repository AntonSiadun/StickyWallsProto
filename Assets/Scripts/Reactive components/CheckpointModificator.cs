using System;
using UnityEngine;
using Zenject;
using Domain.Interactions.Triggered;

public class CheckpointModificator : ReactiveComponent
{
    private LevelGenerator _generator;
    private bool _isUsed = false;

    [Inject]
    public void Initialize(LevelGenerator generator)
    {
        _generator = generator ?? throw new NullReferenceException("Level generator is empty.");
    }

    public override void OnEnter(GameObject anObject)
    {
        if (!_isUsed)
        {
            _generator.GenerateLevelPart(transform.position);
            _isUsed = true;
        }
    }
}
