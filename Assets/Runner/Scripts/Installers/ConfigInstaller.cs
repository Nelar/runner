using Runner.Configs;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Installers/Configs")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField]
        private PlayerConfig _playerConfig;

        [SerializeField]
        private RoadConfig _roadConfig;

        [SerializeField]
        private ObstaclesConfig _obstaclesConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<RoadConfig>().FromInstance(_roadConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<ObstaclesConfig>().FromInstance(_obstaclesConfig).AsSingle();
        }
    }
}