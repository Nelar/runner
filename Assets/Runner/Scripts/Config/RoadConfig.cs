using System.Collections.Generic;
using UnityEngine;

namespace Runner.Configs
{
    [System.Serializable]
    public class RoadConfig
    {
        public enum ObstacleType
        {
            None,
            Accelerator,
            Slower,
            Flighter
        }

        [System.Serializable]
        public class ObstacleSpawnChance
        {
            [SerializeField]
            private ObstacleType _type;

            [SerializeField]
            [Range(0, 100)]
            private int _chance;

            public ObstacleType Type => _type;
            public int Chance => _chance;
        }

        [SerializeField]
        private int _startRoadSectionsCount = 10;

        [SerializeField]
        private float _spawnSectionEveryDistance = 8f;

        [SerializeField]
        private float _obstacleSpawnDistance = 4f;

        [SerializeField]
        private List<ObstacleSpawnChance> _obstacleSpawnChances;

        public IReadOnlyList<ObstacleSpawnChance> ObstacleSpawnChances => _obstacleSpawnChances;

        public int StartRoadSectionsCount => _startRoadSectionsCount;
        public float SpawnSectionEveryDistance => _spawnSectionEveryDistance;
        public float ObstacleSpawnDistance => _obstacleSpawnDistance;
    }
}
