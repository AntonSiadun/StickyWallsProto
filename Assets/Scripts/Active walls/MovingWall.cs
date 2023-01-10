using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interactions.Triggered
{
    public class MovingWall : ReactiveComponent
    {
        [SerializeField] private List<Transform> _path = new List<Transform>();
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _delay = 1f;

        private bool _isReady = true;

        public override void OnEnter(GameObject anObject)
        {
            if (_isReady)
            {
                _isReady = false;
                MoveByRoute();
            }
        }

        private void MoveByRoute()
        {
            Tween tween = transform.DOPath(_path.Select(x => x.position).ToArray(),
                _duration, PathType.Linear, PathMode.Sidescroller2D, 10, Color.blue)
                    .SetEase(Ease.Linear);

            Sequence sequence = DOTween.Sequence();

            sequence.SetDelay(0.5f).Append(tween).AppendInterval(_delay).OnComplete(SetReady);

            sequence.SetLoops(2, LoopType.Yoyo).Play();
        }

        private void SetReady()
        {
             _isReady = true;
        }

        public void OnDestroy()
        {
            DOTween.Clear(transform);
        }
    }
}
