using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HotBall
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbodyPlayer;
        [SerializeField] private InputSetup startInputSetup;
        private readonly List<AbstractState> _states = new List<AbstractState>();
        private readonly List<AbstractData> _dataList = new List<AbstractData>();
        private const float MAX_HP = 100f;
        private float _health = MAX_HP;
        public event Action OnHealthChanged;

        public float GetNormalizedHealth => _health / MAX_HP;
        
        private void Start()
        {
             _states.Add(new Input(startInputSetup));
             OnHealthChanged?.Invoke();
        }

        public void UpdateTick(float deltaTime)
        {
            StatesGenerateData(deltaTime);
            StatesModifyData();
            UpdateStates(deltaTime);
            ClearStates();

            HealthUpdate();
        }

        public bool IsPoisoned => _states.Any(state => state is HealthChangeThatNeedToBeUpdated {HealthDataType: HealthDataType.POISON});

        private void HealthUpdate()
        {
            var isHealthChanged = false;
            
            for (var i = _dataList.Count - 1; i >= 0; i--)
            {
                if (!(_dataList[i] is HealthData healthData)) continue;
                _health += healthData.Value;
                _dataList.RemoveAt(i);
                isHealthChanged = true;
            }

            if (isHealthChanged) OnHealthChanged?.Invoke();
        }

        private void StatesGenerateData(float deltaTime)
        {
            foreach (var state in _states)
                if (state is IStateThatAddData addDataState)
                    _dataList.AddRange(addDataState.AddData(deltaTime));
        }

        private void StatesModifyData()
        {
            foreach (var state in _states) 
                if (state is IStateThatModifyData modifyDataState)
                    modifyDataState.ModifyData(_dataList);
        }

        private void UpdateStates(float deltaTime)
        {
            foreach (var state in _states)
                if (state is IStateThatNeedToBeUpdated updatableState)
                    updatableState.UpdateTick(deltaTime);
        }

        private void ClearStates()
        {
            for (var i = 0; i < _states.Count;)
            {
                
                if (_states[i] is IStateThatCheckDelete checkDeleteState && checkDeleteState.IsNeedDelete())
                    _states.RemoveAt(i);
                else
                    i++;
            }
        }

        public void FixedTick()
        {
            for (var i = _dataList.Count - 1; i >= 0; i--)
            {
                var data = _dataList[i];
                if (data is InputData inputData)
                {
                    Move(inputData.Movement);
                    _dataList.RemoveAt(i);
                    continue;
                }
            }
        }

        private void Move(Vector3 inputDataMovement)
        {
            rigidbodyPlayer.AddForce(inputDataMovement);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ICollectableItem>(out var collectable))
                GameController.Inventory.AddItem(collectable.GiveMeItem());
            
            if (other.TryGetComponent<IAddState>(out var addState))
                _states.Add(addState.GiveMeState());

            if (other.TryGetComponent<InteractiveObject>(out var obj)) obj.Interaction();
        }
    }
}