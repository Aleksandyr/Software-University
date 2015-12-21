namespace ISIS.Interfaces
{
    public interface IHealthRegulator
    {
        int HealthIncrease { get; }

        int HealthDecrase { get; }
    }
}
