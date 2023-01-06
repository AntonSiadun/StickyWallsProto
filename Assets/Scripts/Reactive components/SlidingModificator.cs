using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class SlidingModificator : ReactiveComponent
    {
        [SerializeField] private float _clutch;

        private ICharacter _character;

        [Inject]
        public void Initialize(ICharacter character)
        {
            _character = character;
        }

        public override void OnEnter(GameObject anObject)
        {
            _character.TurnBackFrom( transform.position);
            _character.Stop();
        }

        public override void OnExit(GameObject anObject)
        {
            _character.Restore();
        }

        public override void OnStay(GameObject anObject)
        {
            _character.AddClutch(_clutch);
        }
    }
}