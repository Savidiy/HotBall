using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HotBall
{
    internal sealed class RedKey : InteractiveObject, ICollectableItem, IAnimate, INeedAudioSource
    {
        [SerializeField] private AudioClip collectSound;
        
        private bool _wasCollected;
        private const float DELETE_DURATION = 0.5f;
        private float _timer = DELETE_DURATION;
        private const float SPEED_ROTATION = 20f;
        private Vector3 _beginScale;
        private AudioSource _audioSource;

        private void Start()
        {
            _beginScale = transform.localScale;
            transform.Rotate(Vector3.up, Random.Range(0f, 360f), Space.World);
        }

        public override void Interaction()
        {
            _audioSource.PlayOneShot(collectSound);
            _wasCollected = true;
            _timer = DELETE_DURATION;
        }
        
        public Item GiveMeItem()
        {
            if (_wasCollected) return new Item(ItemType.NONE);
            return new Item(ItemType.RED_KEY);
        }

        public void Animate()
        {
            transform.Rotate(Vector3.up, SPEED_ROTATION * Time.deltaTime, Space.World);
            
            if (!_wasCollected) return;
            
            _timer -= Time.deltaTime;
            var progress = _timer / DELETE_DURATION;
            transform.localScale = _beginScale * progress;

            if (_timer < 0) Destroy(gameObject);
        }

        public void SetAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
    }
}