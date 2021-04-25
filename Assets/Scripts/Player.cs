using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private InputSetup startInputSetup;
        private readonly List<AbstractState> _states = new List<AbstractState>();
        private readonly List<AbstractData> _dataList = new List<AbstractData>();
        private const float MAX_HP = 100f;
        private float _hp = MAX_HP;

        private void Start()
        {
             _states.Add(new InputState(startInputSetup));
        }

        public void UpdateTick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.K)) // todo debug speedlost
            {
                _states.Add(new SpeedChangeState(3, 0.7f));
            }
            
            UpdateStates(deltaTime);
            ClearStates();
            GenerateDataStates();
            ModifyDataStates();
        }

        private void ModifyDataStates()
        {
            foreach (var state in _states) state.ModifyData(_dataList);
        }

        private void GenerateDataStates()
        {
            foreach (var state in _states) _dataList.AddRange(state.AddData());
        }

        private void ClearStates()
        {
            for (var i = 0; i < _states.Count;)
            {
                if (_states[i].IsNeedDelete())
                    _states.RemoveAt(i);
                else
                    i++;
            }
        }

        private void UpdateStates(float deltaTime)
        {
            foreach (var state in _states) state.UpdateTick(deltaTime);
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
            rigidbody.AddForce(inputDataMovement);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ICollectableItem>(out var collectable))
            {
                var item = collectable.GiveMeItem();
                GameController.Inventory.AddItem(item);
            }
            
            if (other.TryGetComponent<InteractiveObject>(out var obj)) obj.Interaction();
        }
    }
}