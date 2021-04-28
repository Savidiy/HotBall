using System.Collections.Generic;

namespace HotBall
{
    public abstract class AbstractState
    {
        
    }

    public interface IStateThatNeedToBeUpdated
    {
        void UpdateTick(float deltaTime);
    }

    public interface IStateThatAddData
    {
        IEnumerable<AbstractData> AddData(float deltaTime);
    }

    public interface IStateThatModifyData
    {
        void ModifyData(List<AbstractData> dataList);
    }

    public interface IStateThatCheckDelete
    {
        bool IsNeedDelete();
    }
}