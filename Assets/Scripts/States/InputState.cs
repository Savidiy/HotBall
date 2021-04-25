using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public class InputState : AbstractState
    {
        private readonly InputSetup _inputSetup;

        public InputState(InputSetup inputSetup)
        {
            _inputSetup = inputSetup;
        }

        public override IEnumerable<AbstractData> AddData()
        {
            var moveHorizontal = Input.GetAxis(_inputSetup.HorizontalAxis);
            var moveVertical = Input.GetAxis(_inputSetup.VerticalAxis);

            var movement = new Vector3(moveHorizontal, 0f, moveVertical);
            movement *= _inputSetup.Speed;

            var data = new InputData(movement);
            return new AbstractData[] {data};
        }
    }
}