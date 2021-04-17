using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private List<Player> players;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed = 5;
        [SerializeField] private float inertiaDistance = 2;

        private void Start()
        {
            transform.position = GetTargetPosition();
        }

        private void FixedUpdate()
        {
            transform.position += CalcDelta();
        }

        private Vector3 CalcDelta()
        {
            var delta = GetTargetPosition() - transform.position;
            var magnitude = delta.magnitude;
            var maxLength = speed * Time.fixedDeltaTime;
            delta = Vector3.ClampMagnitude(delta, maxLength);
            if (magnitude < inertiaDistance) delta *= magnitude / inertiaDistance;
            
            return delta;
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