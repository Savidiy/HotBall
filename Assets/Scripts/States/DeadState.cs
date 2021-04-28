using System.Collections.Generic;

namespace HotBall
{
    public class Dead : AbstractState, IStateThatModifyData
    {
        public void ModifyData(List<AbstractData> dataList)
        {
            for (var i = dataList.Count - 1; i >= 0; i--)
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