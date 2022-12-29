using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class ElascticModificator : ReactiveComponent
    {
        [SerializeField] private float _pushForceMultipier;

        private ICharacter _character;

        [Inject]
        public void Initialize(ICharacter character)
        {
            _character = character;
        }

        public override void OnEnter(GameObject anObject)
        {
            _character.Stop();
            _character.TurnBack();
            _character.Pulse(_pushForceMultipier);

        }

        public override void OnExit(GameObject anObject)
        {
            _character.Restore();
        }
    }
}