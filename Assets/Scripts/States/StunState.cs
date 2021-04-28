using System.Collections.Generic;
using UnityEngine;

namespace HotBall
{
    public sealed class StunState : AbstractState, IStateThatNeedToBeUpdated, IStateThatModifyData, IStateThatCheckDelete
    {
        private float _duration;
        
        public StunState(float duration)
        {
            _duration = duration;
        }
        
        public void UpdateTick(float deltaTime)
        {
            _duration -= deltaTime;
        }

        public void ModifyData(List<AbstractData> dataList)
        {
            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                var data = dataList[i];
                if (data is InputData inputData)
                {
                    inputData.Movement = Vector3.zero;
                }
            }
        }

        public bool IsNeedDelete()
        {
            return _duration < 0;
        }
    }
}