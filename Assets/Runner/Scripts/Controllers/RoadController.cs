using Runner.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Runner.Configs.RoadConfig;
using static System.Collections.Specialized.BitVector32;

namespace Runner.Controllers
{
    public class RoadController
    {
        public struct ObstacleInfo
        {
            private ObstacleType _type;
            private Vector2 _position;

            public ObstacleType Type => _type;
            public Vector2 Position => _position;

            public ObstacleInfo(ObstacleType type, Vector2 position)
            {
                _type = type;
                _position = position;
            }
        }
        public struct RoadSectionInfo
        {
            private float _position;
            private ObstacleInfo _obstacle;
            public float Position => _position;            
            public ObstacleInfo Obstacle => _obstacle;

            public RoadSectionInfo(ObstacleInfo obstacle, float position)
            {
                _position = position;
                _obstacle = obstacle;
            }
        }

        public IReadOnlyList<RoadSectionInfo> Sections => _sections;
        public Action OnRoadUpdate = delegate { };

        private RoadConfig _config;
        private float _lastSectionPosition = 0f;
        private float _playerPositionOffset = 0f;
        private float _lastPlayerPosition = 0f;

        private List<RoadSectionInfo> _sections = new List<RoadSectionInfo>();

        readonly float _obstaclesChanceAllWeight;                

        public RoadController(RoadConfig config, PlayerController player) 
        { 
            _config = config;

            foreach(var obstacleChance in _config.ObstacleSpawnChances)
            {
                _obstaclesChanceAllWeight += obstacleChance.Chance;
            }

            _sections.Add(new RoadSectionInfo(new ObstacleInfo(ObstacleType.None, Vector2.zero), 0.0f));
            for (var i = 1; i < _config.StartRoadSectionsCount; i++)
            {
                SpawnSection();
            }

            player.OnChangePosition += ChangePlayePosition;
        }

        void ChangePlayePosition(Vector3 position)
        {
            _playerPositionOffset += (position.z - _lastPlayerPosition);
            _lastPlayerPosition = position.z;
            if (_playerPositionOffset < _config.SpawnSectionEveryDistance) return;

            _playerPositionOffset -= _config.SpawnSectionEveryDistance;
            SpawnSection();
        }

        void SpawnSection()
        {
            _lastSectionPosition += _config.SpawnSectionEveryDistance;

            var spawnedWeight = Range(0, _obstaclesChanceAllWeight);
            var currentWeight = 0;
            foreach (var obstacleChance in _config.ObstacleSpawnChances)
            {
                currentWeight += obstacleChance.Chance;
                if (spawnedWeight > currentWeight) continue;


                var distance = _config.ObstacleSpawnDistance;
                var position = new Vector2(Range(-distance, distance), Range(-distance, distance));

                var obstacle = new ObstacleInfo(obstacleChance.Type, position);
                var section = new RoadSectionInfo(obstacle, _lastSectionPosition);

                _sections.Add(section);
                break;
            }

            while (_sections.Count > _config.StartRoadSectionsCount)
            {
                _sections.RemoveAt(0);
            }

            OnRoadUpdate();            

            float Range(float min, float max) => UnityEngine.Random.Range(min, max);
        }
    }
}