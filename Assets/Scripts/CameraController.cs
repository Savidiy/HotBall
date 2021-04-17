using UnityEngine;

namespace HotBall
{
    internal class CameraController : MonoBehaviour
    {
        [SerializeField] private Player player;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = player.transform.position + _offset;
        }
    }
}