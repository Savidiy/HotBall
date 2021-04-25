using System.Collections.Generic;

namespace HotBall
{
    public class DeadState : AbstractState
    {
        public override void ModifyData(List<AbstractData> dataList)
        {
            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                var data = dataList[i];
                if (data is InputData)
                {
                    dataList.RemoveAt(i);
                }
            }
        }
    }
}