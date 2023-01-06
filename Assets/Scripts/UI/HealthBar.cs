using UnityEngine;
using Zenject;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _scrollbar;

    [Header("Position")]
    [SerializeField] private Vector3 _offScreen;
    [SerializeField] private Vector3 _onScreen;

    private Health _health;

    [Inject]
    public void Initialize(Health health)
    {
        _health = health ?? throw new NullReferenceException("Health is empty.");
    }

    private void Awake()
    {

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
