using System.Collections.Generic;

namespace HotBall
{
    public sealed class SpeedChangeState : AbstractState
    {
        private float _duration;
        private readonly float _modificator;

        public SpeedChangeState(float duration, float modificator)
        {
            _duration = duration;
            _modificator = modificator;
        }
        
        public override void UpdateTick(float deltaTime)
        {
            _duration -= deltaTime;
        }

        public override void ModifyData(List<AbstractData> dataList)
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

        public override bool IsNeedDelete()
        {
            return _duration < 0;
        }
    }
}