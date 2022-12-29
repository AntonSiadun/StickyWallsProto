using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class ElascticModificator : ReactiveComponent
    {
        [SerializeField] private float _pushForceMultipier;
        [SerializeField] private string _tag;

        private ICharacter _character;

        [Inject]
        public void Initialize(ICharacter character)
        {
            _character = character;
        }

        public override void OnEnter(GameObject anObject)
        {
            if(anObject.CompareTag(_tag))
            {
                _character.Stop();
                _character.TurnBack();
                _character.Pulse(_pushForceMultipier);
            }
        }

        public override void OnExit(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                _character.Restore();
            }
        }

        public override void OnStay(GameObject anObject)
        {

        }
    }
}