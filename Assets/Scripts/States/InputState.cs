using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public class Input : AbstractState, IStateThatAddData
    {
        private readonly InputSetup _inputSetup;

        public Input(InputSetup inputSetup)
        {
            _inputSetup = inputSetup;
        }

        public IEnumerable<AbstractData> AddData(float deltaTime)
        {
            var moveHorizontal = UnityEngine.Input.GetAxis(_inputSetup.HorizontalAxis);
            var moveVertical = UnityEngine.Input.GetAxis(_inputSetup.VerticalAxis);

            var movement = new Vector3(moveHorizontal, 0f, moveVertical);
            movement *= _inputSetup.Speed * deltaTime;

            var data = new InputData(movement);
            return new AbstractData[] {data};
        }
    }
}