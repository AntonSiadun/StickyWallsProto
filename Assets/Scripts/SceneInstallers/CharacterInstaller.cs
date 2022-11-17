using UnityEngine;
using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _character;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MainCharacter>().FromComponentOn(_character).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PhysicMovement>().FromComponentOn(_character).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<NaturalGravity>().FromComponentOn(_character).AsSingle().NonLazy();
    }
}