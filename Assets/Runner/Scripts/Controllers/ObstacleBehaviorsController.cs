using Runner.Configs;
using static Runner.Configs.RoadConfig;

namespace Runner.Controllers
{
    public class ObstacleBehaviorsController
    {
        private ObstaclesConfig _config;
        public ObstacleBehaviorsController(ObstaclesConfig config) 
        {
            _config = config;
        }

        public void RunBehavior(ObstacleType type, PlayerController _player)
        {
               
        }
    }
}
