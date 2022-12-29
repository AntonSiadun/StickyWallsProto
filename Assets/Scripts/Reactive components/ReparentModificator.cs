using UnityEngine;
using Zenject;
using Domain.Movement;

namespace Domain.Interactions.Triggered
{
    public class ReparentModificator : ReactiveComponent
    {
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
            _cachedParent = _characterTransform.parent;
            _characterTransform.parent = _parent;
            Debug.Log("Reparent modificator on object:" + gameObject.name +
                " reparent character to:" + _parent.name);
        }

        public override void OnExit(GameObject anObject)
        {
            _characterTransform.parent = _cachedParent;
            Debug.Log("Reparent modificator on object:" + gameObject.name +
                " restore character parent");
        }
    }
}