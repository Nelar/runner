using Runner.Controllers;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Time.timeScale = 0f;
            Application.targetFrameRate = 60;

            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadController>().AsSingle();
            Container.BindInterfacesAndSelfTo<BehaviorsByObstacleController>().AsSingle();
        }
    }
}