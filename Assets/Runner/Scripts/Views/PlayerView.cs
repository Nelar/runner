using Runner.Controllers;
using UnityEngine;
using Zenject;
using static Runner.Configs.RoadConfig;
using static Runner.Controllers.PlayerController;

namespace Runner.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private string _idleAnimation = "idle";
        [SerializeField]
        private string _runAnimation = "run";
        [SerializeField]
        private string _flyAnimation = "fly";

        [SerializeField]
        private Animator _animator;

        private PlayerController _playerController;

        [Inject]
        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
            _playerController.OnChangePosition += pos => transform.position = pos;
            _playerController.OnChangeState += ChangeState;
        }

        private void ChangeState(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Idle:
                    _animator.SetTrigger(_idleAnimation);
                    break;
                case PlayerState.Run:
                    _animator.SetTrigger(_runAnimation);
                    break;
                case PlayerState.Fly:
                    _animator.SetTrigger(_flyAnimation);
                    break;
            }
        }

        public void TriggeredObstacle(ObstacleType type) => _playerController.TriggeredObstacle(type);
    }
}

