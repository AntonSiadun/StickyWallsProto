using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interactions.Active
{
    public class MovingWall : MonoBehaviour
    {
        [SerializeField] private List<Transform> _path = new List<Transform>();
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _delay = 1f;

        void Start()
        {
            MoveByRoute();
        }

        private void MoveByRoute()
        {
            Tween tween = transform.DOPath(_path.Select(x => x.position).ToArray(),
                _duration, PathType.Linear, PathMode.Sidescroller2D, 10, Color.blue)
                    .SetEase(Ease.Linear);

            Sequence sequence = DOTween.Sequence();

            sequence.SetDelay(_delay).Append(tween).AppendInterval(_delay);

            sequence.SetLoops(-1, LoopType.Yoyo).Play();
        }

        public void OnDestroy()
        {
            DOTween.Clear(transform);
        }
    }
}
