using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Active
{
    public class TurnstileModificator : MonoBehaviour
    {
        [SerializeField] private float _cooldown;

        private MainCharacter _character;

        [Inject]
        public void Initialize(MainCharacter character)
        {
            if (character == null)
                throw new System.NullReferenceException("Character is empty.");

            _character = character;
        }

        private void Start()
        {
            StartCoroutine(TurnDirection());
        }

        public IEnumerator TurnDirection()
        {
            if (_cooldown <= 0)
                throw new System.ArgumentException("Cooldown must be a positive value.");

            for (; ; )
            {
                yield return new WaitForSeconds(_cooldown);
                yield return ChangeLocalScale();
            }
        }

        protected IEnumerator ChangeLocalScale()
        {
            yield return null;

            if( transform == _character.transform.parent)
                _character.TurnBack();

            Debug.Log("Turnstile: "+ gameObject.name+" changed local scale.");
            transform.localScale = new Vector3(-transform.localScale.x,
                                                transform.localScale.y,
                                                transform.localScale.z);
        }
    }
}
