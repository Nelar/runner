using Cysharp.Threading.Tasks;
using Runner.Configs;
using Runner.Controllers;

namespace Runner.Behaviors
{
    public abstract class BaseBehavior
    {
        protected PlayerController _player;
        protected ObstaclesConfig.ObstacleConfig _config;
        public BaseBehavior(PlayerController player, ObstaclesConfig.ObstacleConfig config)
        {
            _player = player;
            _config = config;
        }
        public abstract UniTask Run();
    }
}
