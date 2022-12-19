using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public class SlidingModificator : ReactiveComponent
    {
        [SerializeField] private string _tag;
        [SerializeField] private float _clutch;

        private ICharacter _character;

        [Inject]
        public void Initialize(ICharacter character)
        {
            _character = character;
        }

        public override void OnEnter(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                _character.TurnBack();
                _character.Stop();
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
            if (anObject.CompareTag(_tag))
            {
                _character.AddClutch(_clutch);
            }
        }
    }
}