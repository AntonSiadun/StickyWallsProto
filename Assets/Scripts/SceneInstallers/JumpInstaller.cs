using Zenject;
using UnityEngine;
using AntonSiadun.StickyWallsProto.Domain.Movement.Counters;
using AntonSiadun.StickyWallsProto.Domain.Movement.JumpController;

public class JumpInstaller : MonoInstaller
{
    [SerializeField] private GameObject _jumpController;

    public override void InstallBindings()
    {
        Container.Bind<ICounter>().To<Counter>().AsSingle();
        Container.Bind<ITimer>().To<Timer>().AsSingle();
        Container.BindInterfacesAndSelfTo<LongJump>().FromComponentOn(_jumpController).AsSingle().NonLazy();
    }
}