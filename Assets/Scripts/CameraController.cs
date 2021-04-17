using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private List<Player> players;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed = 4;
        [SerializeField] private float inertiaDistance = 1;

        private void Start()
        {
            transform.position = GetTargetPosition();
        }

        private void FixedUpdate()
        {
            var currentPosition = transform.position;
            var delta = GetTargetPosition() - currentPosition;
            var magnitude = delta.magnitude;
            var length = speed * Time.fixedDeltaTime;
            delta = Vector3.ClampMagnitude(delta, length);
            if (magnitude < inertiaDistance)
                delta *= magnitude / inertiaDistance;

            transform.position = currentPosition + delta;
        }

        private Vector3 GetTargetPosition()
        {
            var targetPosition = new Vector3();
            var playerCount = 0;
            foreach (var player in players)
            {
                if (player == null) continue;
                targetPosition += player.transform.position;
                playerCount++;
            }

            if (playerCount > 0)
                targetPosition /= playerCount;
            
            targetPosition += offset;
            
            return targetPosition;
        }
    }
}