using System;
using UnityEngine;

namespace HotBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private InputSettings inputSettings = InputSettings.Wasd;
        private string _verticalAxis;
        private string _horizontalAxis;

        private void Start()
        {
            switch (inputSettings)
            {
                case InputSettings.Wasd:
                    _horizontalAxis = "HorizontalWASD";
                    _verticalAxis = "VerticalWASD";
                    break;
                case InputSettings.Arrows:
                    _horizontalAxis = "HorizontalArrows";
                    _verticalAxis = "VerticalArrows";
                    break;
                case InputSettings.Joystick:
                    _horizontalAxis = "HorizontalJoystick";
                    _verticalAxis = "VerticalJoystick";
                    break;
                case InputSettings.Mouse:
                    _horizontalAxis = "Mouse X";
                    _verticalAxis = "Mouse Y";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Forgot to add settings");
            }
        }

        protected void Move()
        {
            var moveHorizontal = Input.GetAxis(_horizontalAxis);
            var moveVertical = Input.GetAxis(_verticalAxis);

            var movement = new Vector3(moveHorizontal, 0f, moveVertical);
            
            rigidbody.AddForce(movement * speed);
        }
    }

    public enum InputSettings
    {
        Wasd,
        Arrows,
        Joystick,
        Mouse
    }
}