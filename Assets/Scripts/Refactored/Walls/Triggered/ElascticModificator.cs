using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public class ElascticModificator : ReactiveComponent
    {
        [SerializeField] private float _pushForceMultipier;
        [SerializeField] private string _tag;

        private MainCharacter _character;

        [Inject]
        public void Initialize(MainCharacter character)
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
                Debug.Log("Elastic modificator on object:" + gameObject.name +
                    " punched character with foirce multipier:"+_pushForceMultipier);
            }
        }

        public override void OnExit(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                Debug.Log("Elastic modificator on object:" + gameObject.name +
                    " restored character");
                _character.Restore();
            }
        }

        public override void OnStay(GameObject anObject)
        {

        }
    }
}