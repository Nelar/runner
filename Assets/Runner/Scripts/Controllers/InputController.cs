using UnityEngine;
using Zenject;

namespace Runner.Controllers
{
    //A class that receives data from the joystick or keyboard and passes it to the character controller
    public class InputController : ITickable
    {
        readonly DynamicJoystick _joystick;
        readonly PlayerController _player;

        public InputController(DynamicJoystick joystick, PlayerController player)
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
