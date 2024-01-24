using UnityEngine;

namespace Runner.Configs
{
    //Class with game character configurations
    [System.Serializable]
    public class PlayerConfig
    {
        [SerializeField]
        private float _leftBorder;
        [SerializeField]
        private float _rightBorder;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private float _flyHeight;

        public float LeftBorder => _leftBorder;
        public float RightBorder => _rightBorder;
        public float Speed => _speed;
        public float FlyHeight => _flyHeight;

        public float RotationSpeed => _rotationSpeed;
    }
}
