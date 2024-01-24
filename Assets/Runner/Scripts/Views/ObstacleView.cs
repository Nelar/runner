using UnityEngine;
using static Runner.Configs.RoadConfig;

namespace Runner.Views
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField]
        private ObstacleType _type;

        public void OnTriggerEnter(Collider other)
        {
            var playerView = other.gameObject.GetComponent<PlayerView>();
            if (playerView == null) return;

            playerView.TriggeredObstacle(_type);            
        }
    }
}
