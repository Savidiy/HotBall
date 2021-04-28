using System.Collections.Generic;

namespace HotBall
{
    public sealed class SpeedChange : AbstractState, IStateThatModifyData, IStateThatNeedToBeUpdated, IStateThatCheckDelete
    {
        private float _duration;
        private readonly float _modificator;

        public SpeedChange(float duration, float modificator)
        {
            _duration = duration;
            _modificator = modificator;
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
                    inputData.Movement *= _modificator;
                }
            }
        }

        public bool IsNeedDelete()
        {
            return _duration < 0;
        }
    }
}