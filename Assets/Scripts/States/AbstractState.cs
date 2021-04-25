using System.Collections.Generic;

namespace HotBall
{
    public abstract class AbstractState
    {
        public virtual void UpdateTick(float deltaTime)
        {
        }

        public virtual IEnumerable<AbstractData> AddData()
        {
            return new AbstractData[0];
        }

        public virtual void ModifyData(List<AbstractData> dataList)
        {
        }

        public virtual bool IsNeedDelete()
        {
            return false;
        }
    }
}