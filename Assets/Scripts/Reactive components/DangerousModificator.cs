using UnityEngine;
using Zenject;
using System;

namespace Domain.Interactions.Triggered
{
    public class DangerousModificator : ReactiveComponent
    {
        [SerializeField] private string _tag;

        private IGameStateProvider _provider;

        [Inject]
        public void Initialize(IGameStateProvider provider)
        {
            _provider = provider;
        }

        public override void OnEnter(GameObject anObject)
        {
            if( anObject.CompareTag(_tag) )
            {
                _provider.SetState(GameState.Dead);
            }
        }

        public override void OnExit(GameObject anObject) { }

        public override void OnStay(GameObject anObject) { }
    }
}