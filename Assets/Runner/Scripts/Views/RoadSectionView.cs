using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Runner.Configs.RoadConfig;
using static Runner.Controllers.RoadController;

namespace Runner.Views
{
    //Class describing the view of the road section
    public class RoadSectionView : MonoBehaviour
    {
        [Serializable]
        public class ObstacleByType
        {
            [SerializeField]
            private GameObject _obstacle;
            [SerializeField]
            private ObstacleType _type;

            public GameObject Obstacle => _obstacle;
            public ObstacleType Type => _type;
        }

        [SerializeField]
        private List<ObstacleByType> _obstacles = new List<ObstacleByType>();

        public void Refresh(ObstacleInfo obstacleInfo)
        {
            _obstacles.ForEach(x => x.Obstacle.SetActive(false));

            var obstacle = _obstacles.FirstOrDefault(x => x.Type == obstacleInfo.Type);
            if (obstacle == null) return;

            obstacle.Obstacle.gameObject.SetActive(true);

            var newPosition = obstacle.Obstacle.transform.localPosition;
            newPosition.x = obstacleInfo.Position.x;
            newPosition.z = obstacleInfo.Position.y;

            obstacle.Obstacle.transform.localPosition = newPosition;
        }
    }
}
