using Runner.Views;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    public class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        PlayerView _player;
        [SerializeField]
        RoadView _road;

        public override void InstallBindings()
        {
            Container.Bind<PlayerView>().FromInstance(_player).AsSingle();
            Container.Bind<RoadView>().FromInstance(_road).AsSingle();
        }
    }
}
