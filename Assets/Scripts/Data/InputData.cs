using UnityEngine;

namespace HotBall
{
    public class InputData : AbstractData
    {
        public Vector3 Movement { get; set; }

        public InputData(Vector3 movement)
        {
            Movement = movement;
        }
    }
}