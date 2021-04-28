using UnityEngine;

namespace HotBall
{
    internal sealed class Poison : InteractiveObject, IAnimate, INeedAudioSource, IAddState
    {
        [SerializeField] private AudioClip collectSound;
        [SerializeField] private float duration;
        [SerializeField] private float totalHealthDamage;
        [SerializeField] private float scaleProbability = 0.03f;
        [SerializeField] private float scaleMaxDelta = 0.2f;
        [SerializeField] private float deleteDuration = 0.4f;
        
        private bool _wasCollected;
        private float _deleteTimer;
        private Vector3 _beginScale;
        private AudioSource _audioSource;

        private void Start()
        {
            _beginScale = transform.localScale;
        }

        public override void Interaction()
        {
            _audioSource.PlayOneShot(collectSound);
            _wasCollected = true;
            _deleteTimer = deleteDuration;
        }
        
        public AbstractState GiveMeState()
        {
            return _wasCollected
                ? (AbstractState) new NullState()
                : new HealthChangeThatNeedToBeUpdated(duration, HealthDataType.POISON, -totalHealthDamage);
        }

        public void Animate()
        {
            SetRandomScale();
            if (_wasCollected) DeleteCheck();
        }

        private void SetRandomScale()
        {
            if (Random.Range(0f, 1f) > scaleProbability) return; 
            var newScale = 1f + Random.Range(-scaleMaxDelta, scaleMaxDelta);
            transform.localScale = Vector3.one * newScale;
        }

        private void DeleteCheck()
        {
            _deleteTimer -= Time.deltaTime;
            var progress = _deleteTimer / deleteDuration;
            transform.localScale = _beginScale * progress;

            if (_deleteTimer < 0) Destroy(gameObject);
        }

        public void SetAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public override string ToString()
        {
            return $"{nameof(GetType)}: duration={duration}, damage={totalHealthDamage}";
        }
    }
}