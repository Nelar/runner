using Runner.Behaviors;
using Runner.Configs;
using static Runner.Configs.RoadConfig;

namespace Runner.Controllers
{
    public class BehaviorsByObstacleController
    {
        private ObstaclesConfig _config;
        public BehaviorsByObstacleController(ObstaclesConfig config)
        {
            _config = config;
        }

        public void RunBehavior(ObstacleType type, PlayerController _player)
        {
            BaseBehavior behavior = null;
            switch (type)
            {
                case ObstacleType.Accelerator:
                    behavior = new AcceleratorBehavior(_player, _config.GetConfigFor(type));
                    break;
                case ObstacleType.Slower:
                    behavior = new SlowerBehavior(_player, _config.GetConfigFor(type));
                    break;
                case ObstacleType.Flighter:
                    behavior = new FlighterBehavior(_player, _config.GetConfigFor(type));
                    break;
            }
            _ = behavior.Run();
        }
    }
}
