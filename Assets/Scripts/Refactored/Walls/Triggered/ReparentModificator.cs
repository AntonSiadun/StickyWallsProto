using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public class ReparentModificator : ReactiveComponent
    {
        [SerializeField] private string _tag;
        [SerializeField] private Transform _parent;

        private Transform _characterTransform;

        [Inject]
        public void Initialize(MainCharacter character)
        {
            _characterTransform = character.gameObject.transform;
        }

        private Transform _cachedParent;

        public override void OnEnter(GameObject anObject)
        {
            if ( anObject.CompareTag(_tag) )
            {
                _cachedParent = _characterTransform.parent;
                _characterTransform.parent = _parent;
                Debug.Log("Reparent modificator on object:" + gameObject.name +
                    " reparent character to:"+_parent.name);
            }
        }

        public override void OnExit(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                _characterTransform.parent = _cachedParent;
                Debug.Log("Reparent modificator on object:" + gameObject.name +
                    " restore character parent");
            }
        }

        public override void OnStay(GameObject anObject) { }
    }
}