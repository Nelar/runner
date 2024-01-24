using Cysharp.Threading.Tasks;
using Runner.Configs;
using Runner.Controllers;
using System;

namespace Runner.Behaviors
{
    public class AcceleratorBehavior : BaseBehavior
    {
        private const float _speed = 4f;
        public AcceleratorBehavior(PlayerController player, ObstaclesConfig.ObstacleConfig config): base(player, config) { }
        public override async UniTask Run()
        {
            _player.AddSpeed(_speed);
            await UniTask.Delay(TimeSpan.FromSeconds(_config.Duration));
            _player.AddSpeed(-_speed);
        }
    }
}
