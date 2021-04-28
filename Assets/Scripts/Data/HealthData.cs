namespace HotBall
{
    public sealed class HealthData : AbstractData
    {
        public HealthDataType Type;
        public float Value;

        public HealthData(HealthDataType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}