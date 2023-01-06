using UnityEngine;
using Zenject;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _scrollbar;
    [SerializeField] private float _stepDuration;

    [Header("Position")]
    [SerializeField] private Transform _offScreenPoint;
    [SerializeField] private Transform _onScreenPoint;

    private Health _health;

    [Inject]
    public void Initialize(Health health)
    {
        _health = health ?? throw new NullReferenceException("Health is empty.");
    }

    private void Awake()
    {
        transform.position = _offScreenPoint.position;
    }

    private void Start()
    {
        _health.OnChanged += x => Show(x, _health.Max);
    }

    public void Show(int current, int max)
    {
        _scrollbar.value = (float)current / (float)max;
    }
}
