using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public sealed class HealthChangeThatNeedToBeUpdated : AbstractState, IStateThatNeedToBeUpdated, IStateThatAddData, IStateThatCheckDelete
    {
        private readonly float _duration;
        private float _timer;
        private readonly float _totalHealthChange;
        public HealthDataType HealthDataType { get; }

        public HealthChangeThatNeedToBeUpdated(float duration, HealthDataType type, float totalHealthChange)
        {
            _duration = duration;
            _timer = _duration; 
            HealthDataType = type;
            _totalHealthChange = totalHealthChange;
        }
        
        public void UpdateTick(float deltaTime)
        {
            _timer -= deltaTime;
        }

        public IEnumerable<AbstractData> AddData(float deltaTime)
        {
            var time = Mathf.Max(0, Mathf.Min(_timer, deltaTime));
            var deltaHealth = _totalHealthChange * time / _duration;
            var data = new HealthData(HealthDataType, deltaHealth);
            return new AbstractData[] {data};
        }

        public bool IsNeedDelete()
        {
            return _timer < 0;
        }
    }
}