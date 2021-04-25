using UnityEngine;

namespace HotBall
{
    [CreateAssetMenu(fileName = "New InputSetup", menuName = "InputSetup", order = 51)]
    public class InputSetup : ScriptableObject
    {
        public string HorizontalAxis;
        public string VerticalAxis;
        public float Speed;
    }
}