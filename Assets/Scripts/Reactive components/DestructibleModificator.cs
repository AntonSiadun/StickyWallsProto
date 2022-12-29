using System.Collections;
using UnityEngine;

namespace Domain.Interactions.Triggered
{
    public class DestructibleModificator : ReactiveComponent
    {
        [SerializeField] private string _tag;
        [SerializeField] private float _cooldawn = 2f;

        private BoxCollider2D _collider;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _renderer = GetComponent<SpriteRenderer>();

            if (_collider == null || _renderer == null)
                throw new System.NullReferenceException("Wall doesn't have a collider or renderer.");
        }

        public override void OnExit(GameObject anObject)
        {
            if (anObject.CompareTag(_tag))
            {
                if (_collider == null)
                    throw new System.NullReferenceException("Empty collider.");

                StartCoroutine(DisableColliderForTime());
            }
        }

        private IEnumerator DisableColliderForTime()
        {
            if (_cooldawn < 0)
                throw new System.ArgumentException("Cooldawn value must be non-zero value.");

            DisableWall();

            yield return new WaitForSeconds(_cooldawn);

            EnableWall();
        }

        private void DisableWall()
        {
            Debug.Log("Destructible modificator on object:" + gameObject.name +
                    " disabled collider");
            _collider.enabled = false;
            _renderer.enabled = false;
        }

        private void EnableWall()
        {
            Debug.Log("Destructible modificator on object:" + gameObject.name +
                    " enabled collider");
            _collider.enabled = true;
            _renderer.enabled = true;
        }

        public override void OnEnter(GameObject anObject) { }

        public override void OnStay(GameObject anObject) { }
    }
}