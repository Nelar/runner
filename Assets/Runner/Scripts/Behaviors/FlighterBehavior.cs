using Cysharp.Threading.Tasks;
using Runner.Configs;
using Runner.Controllers;
using System;

namespace Runner.Behaviors
{
    public class FlighterBehavior : BaseBehavior
    {
        public FlighterBehavior(PlayerController player, ObstaclesConfig.ObstacleConfig config) : base(player, config) { }
        public override async UniTask Run()
        {
            _player.SetState(PlayerController.PlayerState.Fly);
            await UniTask.Delay(TimeSpan.FromSeconds(_config.Duration));
            _player.SetState(PlayerController.PlayerState.Run);
        }
    }
}
