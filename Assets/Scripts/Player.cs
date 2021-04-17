using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HotBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private Rigidbody rb;

        protected void Move()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0f, moveVertical);
            
            rb.AddForce(movement * speed);
        }
    }
}