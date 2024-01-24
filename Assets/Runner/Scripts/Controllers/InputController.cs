using UnityEngine;
using Zenject;

namespace Runner.Controllers
{
    public class InputController : ITickable
    {        
        VariableJoystick _joystick;
        PlayerController _player;

        public InputController(VariableJoystick joystick, PlayerController player)
        {
            _joystick = joystick;
            _player = player;
        }

        public void Tick()
        {
            var direction = _joystick.Horizontal;

            if (Mathf.Approximately(direction, 0f))
            {
                var left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
                var right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

                direction = (left ? -1.0f : 0.0f) + (right ? 1.0f : 0.0f);
            }
            _player.MoveToDirection(direction);
        }        
    }
}
