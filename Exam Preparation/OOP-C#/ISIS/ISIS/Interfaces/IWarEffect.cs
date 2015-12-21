namespace ISIS.Interfaces
{
    public interface IWarEffect : IMultipleRegulator, IHealthRegulator, IDamageRegulator, IUpdateable
    {
        bool IsAlreadyUsed { get; }
    }
}
