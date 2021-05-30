using UnityEngine;

namespace HotBall
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerStartPosition;
        public Transform PlayerStartPosition => playerStartPosition;
    }
}