using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public class SlidingModificator : ReactiveComponent
    {
        [SerializeField] private string _tag;
        [SerializeField] private float _clutch;

        private MainCharacter _character;

        [Inject]
        public void Initialize(MainCharacter character)
        {
            _character = character;
        }

        public override void OnEnter(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                Debug.Log("Sliding modificator on object:"+gameObject.name+" enter character");
                _character.TurnBack();
                _character.Stop();
            }
        }

        public override void OnExit(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                Debug.Log("Sliding modificator on object:" + gameObject.name + " exit character");
                _character.Restore();
            }
        }

        public override void OnStay(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                Debug.Log("Sliding modificator on object:" + gameObject.name + " stay character");
                _character.AddClutch(_clutch);
            }
        }
    }
}