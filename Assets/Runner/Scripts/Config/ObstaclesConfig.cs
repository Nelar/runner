using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Runner.Configs.RoadConfig;

namespace Runner.Configs
{
    //A class with configs for obstacles
    [Serializable]    
    public class ObstaclesConfig
    {
        [Serializable]
        public class ObstacleConfig
        {
            [SerializeField]
            private ObstacleType _type;
            [SerializeField]
            private float _duration;

            public ObstacleType Type => _type;

            //Time of behavioral action after collision with an obstacle
            public float Duration => _duration;
        }

        [SerializeField]
        private List<ObstacleConfig> _obstacles = new List<ObstacleConfig>();        

        public ObstacleConfig GetConfigFor(ObstacleType type) => _obstacles.FirstOrDefault(x => x.Type == type);
    }
}
