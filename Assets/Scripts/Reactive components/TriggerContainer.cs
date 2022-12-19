using UnityEngine;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public class TriggerContainer : MonoBehaviour
    {
        private ReactiveComponent[] _reactives;

        private void Start()
        {
            _reactives = GetComponents<ReactiveComponent>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            foreach (var reactive in _reactives)
                reactive.OnEnter(collision.gameObject);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            foreach (var reactive in _reactives)
                reactive.OnStay(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            foreach (var reactive in _reactives)
                reactive.OnExit(collision.gameObject);
        }
    }
}