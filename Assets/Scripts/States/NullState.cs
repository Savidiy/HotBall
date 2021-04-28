namespace HotBall
{
    public sealed class NullState : AbstractState, IStateThatCheckDelete
    {
        public bool IsNeedDelete()
        {
            return true;
        }
    }
}