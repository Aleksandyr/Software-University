namespace Empires.Interfaces
{
    public interface IScheduleResourceProducer : IResourceProducer
    {
        bool CanProduceResource { get; }
    }
}
