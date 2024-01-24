using Runner.Controllers;
using Zenject;

namespace Runner.Installers
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadController>().AsSingle();
            Container.BindInterfacesAndSelfTo<BehaviorsByObstacleController>().AsSingle();
        }
    }
}