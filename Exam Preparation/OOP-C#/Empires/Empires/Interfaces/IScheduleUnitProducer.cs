namespace Empires.Interfaces
{
    public interface IScheduleUnitProducer : IUnitProducer
    {
        bool CanProduceUnit { get; }
    }
}
