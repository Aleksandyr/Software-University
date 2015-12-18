namespace Empires.Interfaces
{
    using Empires.Enums;

    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
