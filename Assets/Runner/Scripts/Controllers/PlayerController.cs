using Runner.Configs;
using System;
using UnityEngine;
using Zenject;
using static Runner.Configs.RoadConfig;
using DG.Tweening;

namespace Runner.Controllers
{
    public class PlayerController : ITickable
    {
        public enum PlayerState
        {
            Idle,
            Run,
            Fly
        }

        public Action<Vector3> OnChangePosition = delegate { };
        public Action<PlayerState> OnChangeState = delegate { };

        readonly PlayerConfig _config;
        readonly BehaviorsByObstacleController _behaviorsController;

        private Vector3 _position = Vector3.zero;
        private PlayerState _state = PlayerState.Run;

        private float _direction = 0f;
        private float _speed = 1f;

        public PlayerController(PlayerConfig config, BehaviorsByObstacleController behaviorsController)
        {
            _config = config;
            _speed = _config.Speed;
            _behaviorsController = behaviorsController;
        }

        public void Tick()
        {
            if (_state == PlayerState.Idle)
                return;
            
            var direction = Vector3.forward * _speed + Vector3.right * _direction * _config.RotationSpeed;

            var position = _position + direction * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, _config.LeftBorder, _config.RightBorder);
            _position = position;

            OnChangePosition(_position);
        }

        public void SetState(PlayerState state)
        {
            if (state == _state) return;

            var prevState = _state;
            _state = state;

            OnChangeState(_state);

            if (_state == PlayerState.Fly)
            {
                DOTween.To(() => _position.y, y => _position.y = y, _position.y +_config.FlyHeight, 0.3f).SetEase(Ease.OutQuad);
            }

            if (prevState == PlayerState.Fly)
            {
                DOTween.To(() => _position.y, y => _position.y = y, _position.y - _config.FlyHeight, 0.3f).SetEase(Ease.OutQuad);
            }            
        }

        public void AddSpeed(float speed)
        {
            _speed += speed;
            if (_speed < 0f) _speed = 0f;
        }
        public void MoveToDirection(float direction) => _direction = direction;
        public void TriggeredObstacle(ObstacleType type) => _behaviorsController.RunBehavior(type, this);
    }
}
