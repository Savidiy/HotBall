namespace HotBall
{
    public abstract class InteractiveObject
    {
        protected abstract void Interaction();
    }

    public sealed class GoodBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            // Add bonus
        }
    }
}