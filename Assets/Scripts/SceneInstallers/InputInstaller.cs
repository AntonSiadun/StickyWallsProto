using Zenject;
using AntonSiadun.StickyWallsProto.Domain.Movement.Input;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IConcreteInputSignature>().To<PCInputSignature>().AsSingle();
        Container.Bind<IInput>().To<InputController>().FromNewComponentOnNewGameObject().AsSingle();
    }
}