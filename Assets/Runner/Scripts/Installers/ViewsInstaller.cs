using Runner.Views;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    //Installer in DI for MonoBehavior views
    public class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerView _player;
        [SerializeField]
        private RoadView _road;

        public override void InstallBindings()
        {
            Container.Bind<PlayerView>().FromInstance(_player).AsSingle();
            Container.Bind<RoadView>().FromInstance(_road).AsSingle();
        }
    }
}
